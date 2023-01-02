using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AVGMachine : MonoBehaviour
{
    //״̬
    public enum State
    {
        //�ر�
        Stop,
        //����
        Playing,
        //������ɣ���һ��
        Paused,
        //ѡ��
        Choice
    }
    public State state;

    //�״ν���
    public bool justEnter;
    //�Ի�
    
    //UI������
    public UIPanel uIPanel;
   
    //AVGData����
    public AVGData data;
    
    //AudioManager��Ƶ������
    public AudioManager audioManager;
    //����������
    public SceneControl sceneControl;

    [SerializeField]
    //��Ӧ�к�
    private int curLine;
    //����Ч��ʵ��
    public string targetString;
    //����ʱ��
    [SerializeField]
    public float timerValue;
    [SerializeField]
    //�����ٶ�
    [Range(1,100)]
    public float typingSpeed;
    // Start is called before the first frame update
    void Start()
    {
        //��ʼ��
        Init();
        //��ʼ������
        state = State.Playing;
        //��Ϊ�״ν���
        justEnter = true;
       
    }

    // Update is called once per frame
    void Update()
    {
        //״̬�ж�
        switch (state)
        {
            case State.Stop:
                if (justEnter)
                {
                    //��ʾ��ת��һ����ť
                    uIPanel.ShowNextSceneBtn(true);
                    justEnter = false;
                    
                }
                
                break; 
            case State.Playing:
                if (justEnter)
                {
                    justEnter = false;
                    //��ʾUI
                    ShowUI();
                    //���ô���ʱ��
                    timerValue = 0;
                    //���ٶ�ȡ
                    typingSpeed = data.contents[curLine].DialogSpeed;
                    //����BGM
                    audioManager.PlayBgm(data.contents[curLine].BgmAudio);
                    //���ر���ͼ
                    LoadBackGround(data.contents[curLine].BackGround);
                    //��ȡ����ͼƬ
                    LoadCharaTexture(data.contents[curLine].CharaATex, data.contents[curLine].CharaBTex);
                    //���ŶԻ�
                    LoadContent(data.contents[curLine].dialogText, data.contents[curLine].CharaADisplay, data.contents[curLine].CharaBDisplay,data.contents[curLine].CharaAudio);
                }
                //�Ƿ񲥷����
                CheckTypingFinished();
                //�Ƿ�ֹͣ��������
                CheckAudioPlay();
                //����Ч��
                UpdateContentString();
                break;
            case State.Paused:
                //�����������Ϊ����
                if (justEnter)
                {
                    justEnter = false;
                }
                break;

                //ѡ��ģʽ
            case State.Choice:
                if (justEnter)
                {
                    //��ʼ��������ť
                    uIPanel.ShowButtons(true);
                    //�޸�ѡ������
                    uIPanel.SetButtonTexts(data.contents[curLine].BtAText, data.contents[curLine].BtBText);
                    //�޸�����
                    uIPanel.SetButtonNames(data.contents[curLine].BtAmsg, data.contents[curLine].BtBmsg);
                    justEnter = false;
                }
                
                break;
            default: 
                break;

        }
        
    }

    public void UserClicked()
    {
        
        //״̬�ж�
        switch (state)
        {
            case State.Stop:
                
                break;
            case State.Playing:
                
                break;
            case State.Paused:
                NextLine();
                if (curLine >= data.contents.Count)
                {
                    //�л���ֹͣ״̬
                    GoToState(State.Stop);
                }
                else
                {
                    //�л�������ģʽ
                    GoToState(State.Playing);
                }
                break;
                //ѡ��״̬
            case State.Choice:
                    break;
            default:
                break;

        }
    }
    //��ʼAVG
    public void StartAVG()
    {
        Init();
        GoToState(State.Playing);
    }
    //�ж��Ƿ���ֲ������
    private void CheckTypingFinished()
    {
        if (state == State.Playing)
        {
            //�����������
            if (Mathf.Min((int)Mathf.Floor(timerValue * typingSpeed)) >= targetString.Length)
            {
                if (data.contents[curLine].Ischoice)
                {

                    //ѡ��״̬����ͣ�Ի�
                    GoToState(State.Choice);
                    return;
                }
                else
                {
                    //������һ��
                    GoToState(State.Paused);
                }
               
            }
            
        }
    }

    //��Ƶֹͣ����
    private void CheckAudioPlay()
    {
        if (state == State.Paused)
        {
            if (Mathf.Min((int)Mathf.Floor(timerValue * typingSpeed)) >= targetString.Length)
            {
                audioManager.StopSound();
                Debug.Log("ֹͣ��������");
            }
            
        }
    }
    
    //��ʼ��
    void Init()
    {
        //����UI
        HideUI();
        //�Ի����������
        curLine = 0;
        //���öԻ�����Ϊ��
        uIPanel.ShowContentText("");
        //���ٶ�ȡ
        typingSpeed = data.contents[curLine].DialogSpeed;
        //���ر���ͼ
        LoadBackGround(data.contents[curLine].BackGround);
        //���ضԻ�
        LoadContent(data.contents[curLine].dialogText, data.contents[curLine].CharaADisplay, data.contents[curLine].CharaBDisplay, data.contents[curLine].CharaAudio);
        //����ѡ��
        uIPanel.ShowButtons(false);
        
    }
    //ת��״̬
    private void GoToState(State nextstate)
    {
        //�л�
        state = nextstate;
        //�״ν���
        justEnter = true;

    }
    //��ʾUI
    void ShowUI()
    {
        uIPanel.ShowCanvas(true);
    }
    //����UI
    void HideUI()
    {
        uIPanel.ShowCanvas(false);
    }
    //��һ��Ի�
    void NextLine()
    {
        curLine++;
    }

    //����Ч��
    void UpdateContentString()
    {
        //����ʱ��
        timerValue += Time.deltaTime;
        //���ֳ��ȣ����ִ��ʱ�䣬typingSpeedΪ�ٶȿ���
        string tempString = targetString.Substring(0, Mathf.Min((int)Mathf.Floor(timerValue * typingSpeed), targetString.Length));
        //����ʾ����
        uIPanel.ShowContentText(tempString);
    }
    //���ر���ͼƬ
    void LoadBackGround(Texture bgTex)
    {
        //���ñ���
        uIPanel.ShowBackGround(bgTex);
    }
    //���ŶԻ�������
    void LoadContent(string value,bool charaADisplay,bool charaBDisplay,AudioClip charaAudioClip)
    {
        //��ʾ�Ի�����
        //uIPanel.ShowContentText(value);
        targetString = value;
        uIPanel.ShowCharA(charaADisplay);
        uIPanel.ShowCharB(charaBDisplay);
        if (data.contents[curLine].CharaAudio != null)
        {
            audioManager.PlaySound(charaAudioClip);
        }
    }
 
    //���ؽ�ɫͼƬ
    void LoadCharaTexture(Texture charaATex,Texture charaBTex)
    {
        uIPanel.ChangeCharaATex(charaATex);
        uIPanel.ChangeCharaBTex(charaBTex);
    }

    //ѡ����Ϣ����
    public void ProcessBtnMSG(GameObject obj)
    {
        //��ȡ����
        string readDataName = obj.name;
        //��Resources��ȡ
        AVGData tempData = Resources.Load<AVGData>(readDataName);
        //װ������
        data = tempData;
        //��ʼ��
        Init();
        //��ȡ����ͼƬ
        LoadCharaTexture(data.contents[curLine].CharaATex, data.contents[curLine].CharaBTex);
        curLine = 0;
        uIPanel.ShowCanvas(true);
        GoToState(State.Playing);
        justEnter = false;

        Debug.Log("��ȡ�¾����ļ�");

    }
    //������ת
    public void BtnLoadNextScene(GameObject obj)
    {
        int LoadSceneNum;
        //��ȡ������Ų���ת����
        LoadSceneNum = data.contents[curLine -1].NextSceneNum;
        sceneControl.LoadScene(LoadSceneNum);
        Debug.Log("������ת");
    }
}
