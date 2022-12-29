using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    //״̬
    public enum PlayState
    {
        Playing,
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

            case PlayState.Playing:
                StopAuto();
                break;
            default:
                break;
        }
    }

    void Play()
    {
        if (Input.GetMouseButtonDown(0))
        {
            machine.UserClicked();
        }
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
        GoToState(PlayState.Playing);
    }
}
