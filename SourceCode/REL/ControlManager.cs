using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 控制管理器脚本
/// </summary>
public class ControlManager : MonoBehaviour
{
    //状态
    public enum PlayState
    {
        UserPlay,
        AutoPlay
    }
    public PlayState playstate;


    //AVG
    public AVGMachine machine;
    private float timerValue;
    private float typingSpeed;
    private string targetString;

    //UI
    public UIPanel uIPanel;
    //计时器
    private float NextTimer;
    //public float nextTimer;

    // Start is called before the first frame update
    void Start()
    {
        machine.StartAVG();
    }

    // Update is called once per frame
    void Update()
    {
        Play();
        switch (playstate)
        {
            case PlayState.AutoPlay:
                //自动播放
                AutoPlay();
                break;

            case PlayState.UserPlay:
                StopAuto();
                break;
            default:
                break;
        }
    }

    void Play()
    {
        if (machine == null)
        {
            Debug.LogError("AVG Machine没有找到");
        }
        //多平台适配
        //Win/Linux/MacOS/WebGL
#if UNITY_STANDALONE_WIN || UNITY_STANDALONE_LINUX || UNITY_WEBGL ||UNITY_STANDALONE_OSX
        if (Input.GetMouseButtonDown(0))
        {
            machine.UserClicked();
        }

        //Android/iOS
#elif UNITY_ANDROID || UNITY_IOS
        if (Input.touchCount == 1)
        {
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                machine.UserClicked();
            }
        }
#else

        Debug.Log("未知平台，无法验证兼容性")
#endif

    }
    void AutoPlay()
    {
        //隐藏按钮，自动播放
        uIPanel.ShowStopAutoButton(true);
        uIPanel.ShowAutoPlayButton(false);
        timerValue = machine.timerValue;
        typingSpeed = machine.typingSpeed;
        targetString = machine.targetString;

        NextTimer++;
        if ((Mathf.Min((int)Mathf.Floor(timerValue * typingSpeed)) >= targetString.Length) && (NextTimer >= 4))
        {
            NextTimer = 0;
            machine.UserClicked();

        }
    }
    void StopAuto()
    {
        uIPanel.ShowAutoPlayButton(true);
        uIPanel.ShowStopAutoButton(false);

    }
    //状态切换
    void GoToState(PlayState nextState)
    {
        playstate = nextState;
    }

    //按钮操作转换
    public void StartAutoBtn(Button btn)
    {
        GoToState(PlayState.AutoPlay);

    }

    public void StopAutoBtn(Button btn)
    {
        GoToState(PlayState.UserPlay);
    }
}
