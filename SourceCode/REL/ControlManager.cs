using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ���ƹ������ű�
/// </summary>
public class ControlManager : MonoBehaviour
{
    //״̬
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
    //��ʱ��
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
                //�Զ�����
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
            Debug.LogError("AVG Machineû���ҵ�");
        }
        //��ƽ̨����
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

        Debug.Log("δ֪ƽ̨���޷���֤������")
#endif

    }
    void AutoPlay()
    {
        //���ذ�ť���Զ�����
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
    //״̬�л�
    void GoToState(PlayState nextState)
    {
        playstate = nextState;
    }

    //��ť����ת��
    public void StartAutoBtn(Button btn)
    {
        GoToState(PlayState.AutoPlay);

    }

    public void StopAutoBtn(Button btn)
    {
        GoToState(PlayState.UserPlay);
    }
}
