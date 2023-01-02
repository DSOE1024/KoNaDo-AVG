using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AVGMachine : MonoBehaviour
{
    //状态
    public enum State
    {
        //关闭
        Stop,
        //播放
        Playing,
        //播放完成，下一个
        Paused,
        //选择
        Choice
    }
    public State state;

    //首次进入
    public bool justEnter;
    //对话
    
    //UI控制器
    public UIPanel uIPanel;
   
    //AVGData数据
    public AVGData data;
    
    //AudioManager音频管理器
    public AudioManager audioManager;
    //场景控制器
    public SceneControl sceneControl;

    [SerializeField]
    //对应行号
    private int curLine;
    //打字效果实现
    public string targetString;
    //打字时间
    [SerializeField]
    public float timerValue;
    [SerializeField]
    //打字速度
    [Range(1,100)]
    public float typingSpeed;
    // Start is called before the first frame update
    void Start()
    {
        //初始化
        Init();
        //初始化播放
        state = State.Playing;
        //不为首次进入
        justEnter = true;
       
    }

    // Update is called once per frame
    void Update()
    {
        //状态判断
        switch (state)
        {
            case State.Stop:
                if (justEnter)
                {
                    //显示跳转下一个按钮
                    uIPanel.ShowNextSceneBtn(true);
                    justEnter = false;
                    
                }
                
                break; 
            case State.Playing:
                if (justEnter)
                {
                    justEnter = false;
                    //显示UI
                    ShowUI();
                    //重置打字时间
                    timerValue = 0;
                    //语速读取
                    typingSpeed = data.contents[curLine].DialogSpeed;
                    //播放BGM
                    audioManager.PlayBgm(data.contents[curLine].BgmAudio);
                    //加载背景图
                    LoadBackGround(data.contents[curLine].BackGround);
                    //读取人物图片
                    LoadCharaTexture(data.contents[curLine].CharaATex, data.contents[curLine].CharaBTex);
                    //播放对话
                    LoadContent(data.contents[curLine].dialogText, data.contents[curLine].CharaADisplay, data.contents[curLine].CharaBDisplay,data.contents[curLine].CharaAudio);
                }
                //是否播放完成
                CheckTypingFinished();
                //是否停止播放配音
                CheckAudioPlay();
                //打字效果
                UpdateContentString();
                break;
            case State.Paused:
                //如果是则设置为不是
                if (justEnter)
                {
                    justEnter = false;
                }
                break;

                //选择模式
            case State.Choice:
                if (justEnter)
                {
                    //初始化两个按钮
                    uIPanel.ShowButtons(true);
                    //修改选项内容
                    uIPanel.SetButtonTexts(data.contents[curLine].BtAText, data.contents[curLine].BtBText);
                    //修改名称
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
        
        //状态判断
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
                    //切换到停止状态
                    GoToState(State.Stop);
                }
                else
                {
                    //切换到输入模式
                    GoToState(State.Playing);
                }
                break;
                //选择状态
            case State.Choice:
                    break;
            default:
                break;

        }
    }
    //开始AVG
    public void StartAVG()
    {
        Init();
        GoToState(State.Playing);
    }
    //判断是否打字播放完成
    private void CheckTypingFinished()
    {
        if (state == State.Playing)
        {
            //如果打完字了
            if (Mathf.Min((int)Mathf.Floor(timerValue * typingSpeed)) >= targetString.Length)
            {
                if (data.contents[curLine].Ischoice)
                {

                    //选择状态，暂停对话
                    GoToState(State.Choice);
                    return;
                }
                else
                {
                    //跳到下一个
                    GoToState(State.Paused);
                }
               
            }
            
        }
    }

    //音频停止播放
    private void CheckAudioPlay()
    {
        if (state == State.Paused)
        {
            if (Mathf.Min((int)Mathf.Floor(timerValue * typingSpeed)) >= targetString.Length)
            {
                audioManager.StopSound();
                Debug.Log("停止播放配音");
            }
            
        }
    }
    
    //初始化
    void Init()
    {
        //隐藏UI
        HideUI();
        //对话索引到最初
        curLine = 0;
        //设置对话内容为空
        uIPanel.ShowContentText("");
        //语速读取
        typingSpeed = data.contents[curLine].DialogSpeed;
        //加载背景图
        LoadBackGround(data.contents[curLine].BackGround);
        //加载对话
        LoadContent(data.contents[curLine].dialogText, data.contents[curLine].CharaADisplay, data.contents[curLine].CharaBDisplay, data.contents[curLine].CharaAudio);
        //隐藏选项
        uIPanel.ShowButtons(false);
        
    }
    //转换状态
    private void GoToState(State nextstate)
    {
        //切换
        state = nextstate;
        //首次进入
        justEnter = true;

    }
    //显示UI
    void ShowUI()
    {
        uIPanel.ShowCanvas(true);
    }
    //隐藏UI
    void HideUI()
    {
        uIPanel.ShowCanvas(false);
    }
    //下一句对话
    void NextLine()
    {
        curLine++;
    }

    //打字效果
    void UpdateContentString()
    {
        //增加时间
        timerValue += Time.deltaTime;
        //文字长度，文字打出时间，typingSpeed为速度控制
        string tempString = targetString.Substring(0, Mathf.Min((int)Mathf.Floor(timerValue * typingSpeed), targetString.Length));
        //逐渐显示文字
        uIPanel.ShowContentText(tempString);
    }
    //加载背景图片
    void LoadBackGround(Texture bgTex)
    {
        //设置背景
        uIPanel.ShowBackGround(bgTex);
    }
    //播放对话和人物
    void LoadContent(string value,bool charaADisplay,bool charaBDisplay,AudioClip charaAudioClip)
    {
        //显示对话内容
        //uIPanel.ShowContentText(value);
        targetString = value;
        uIPanel.ShowCharA(charaADisplay);
        uIPanel.ShowCharB(charaBDisplay);
        if (data.contents[curLine].CharaAudio != null)
        {
            audioManager.PlaySound(charaAudioClip);
        }
    }
 
    //加载角色图片
    void LoadCharaTexture(Texture charaATex,Texture charaBTex)
    {
        uIPanel.ChangeCharaATex(charaATex);
        uIPanel.ChangeCharaBTex(charaBTex);
    }

    //选项消息索引
    public void ProcessBtnMSG(GameObject obj)
    {
        //读取名称
        string readDataName = obj.name;
        //从Resources读取
        AVGData tempData = Resources.Load<AVGData>(readDataName);
        //装载数据
        data = tempData;
        //初始化
        Init();
        //读取人物图片
        LoadCharaTexture(data.contents[curLine].CharaATex, data.contents[curLine].CharaBTex);
        curLine = 0;
        uIPanel.ShowCanvas(true);
        GoToState(State.Playing);
        justEnter = false;

        Debug.Log("读取新剧情文件");

    }
    //场景跳转
    public void BtnLoadNextScene(GameObject obj)
    {
        int LoadSceneNum;
        //读取场景序号并跳转场景
        LoadSceneNum = data.contents[curLine -1].NextSceneNum;
        sceneControl.LoadScene(LoadSceneNum);
        Debug.Log("场景跳转");
    }
}
