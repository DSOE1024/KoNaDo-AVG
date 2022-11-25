using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GalManager : MonoBehaviour
{

    //CG播放系统
    public GameObject CGPlayer;
    //人物音频系统
    public AudioSource DialogueAudio;
    //BGM背景乐
    public AudioSource BGM;
    //背景
    public Image Background;
    //角色1图片
    public Image ActorImage1;
    //角色二图片
    //public Image ActorImage2;
    //对话角色姓名文本
    public Text ActorName;
    //对话文本
    public Text ContentText;
    //完整对话内容
    public List<Message> messages;
    //当前对话位置
    public int index = 0;
    //完成对话后跳转的场景(默认回到剧情页)
    public int PageNumber = 1;



    // Start is called before the first frame update
    void Start()
    {
        

        //创建数组对象
        messages = new List<Message>();
        //在这里创建对话
        //创建对话
        //msg = new Message() { Name = "角色姓名", Content = "对话内容", ImageName = "角色图片名称（/Resource/Actor文件夹下）" Audio = "音频名称" };
        //messages.Add(msg);
        //切换背景
        //msg = new Message() { type= MessageType.Background,Background = "背景名称"};
        //messages.Add(msg);
        //播放BGM
        // msg = new Message() { type = MessageType.BGM, BGM = "音频名称"};
        // messages.Add(msg);
        //场景跳转
        //msg = new Message() { type = MessageType.SceneLoad };
        //messages.Add(msg);
        
        //eg

        Message
            msg = new Message() { type = MessageType.Background, Background = "BG2" };
        messages.Add(msg);

        msg = new Message() { type = MessageType.BGM, BGM = "BGM1YS"};
        messages.Add(msg);
        msg = new Message() { Name = "1024", Content = "程序测试第一句话", ImageName = "BYJC" };
        messages.Add(msg);
        msg = new Message() { Name = "1024", Content = "程序测试第一句话", ImageName = "BYJC" };
        messages.Add(msg);
        msg = new Message() { Name = "1024", Content = "程序测试第一句话", ImageName = "BYJC" };
        messages.Add(msg);
        msg = new Message() { type = MessageType.SceneLoad };
        messages.Add(msg);

    }

    Message GetMessage()
    {
        if (index < messages.Count)
        {
            //返回索引位置
            return messages[index++];
        }
        //索引越界，返回null
        return null;
    }

    void Update()
    {
        //触屏多点触控
        Input.multiTouchEnabled = true;

        //点击鼠标左键
        if (Input.GetMouseButtonDown(0))
        {
            //进行对话
            Message();
        }

    }
    
    void Message()
    {
        //获取一句对话
        Message msg = GetMessage();
        //如果对话不为null，则当前有对话
        if (msg != null)
        {
            //内容为消息
            if (msg.type == MessageType.Message)
            {
                
                //在对话前暂停播放CG
                CGPlayer.SetActive(false);
                //获取角色图片名称
                ActorImage1.sprite = Resources.Load<Sprite>("Actor/" + msg.ImageName);
                //ActorImage2.sprite = Resources.Load<Sprite>("Actor/" + msg.ImageName);

                //显示角色名称
                ActorName.text = msg.Name;
                //显示对话内容
                ContentText.text = msg.Content;
                //播放对话
                //先暂停上一条对话
                DialogueAudio.Stop();
                DialogueAudio.PlayOneShot(Resources.Load<AudioClip>("Audio/ActorAudio/" + msg.Audio));

            }

            //内容为切换背景
            if (msg.type == MessageType.Background)
            {
                //获取背景图片
                Background.sprite = Resources.Load<Sprite>("Background/" + msg.Background);
                //自动下一句
                Message();

            }
            //BGM播放类
            if (msg.type == MessageType.BGM)
            {
                BGM.PlayOneShot(Resources.Load<AudioClip>("Audio/BGM/" + msg.BGM));
                //自动下一句
                Message();
            }

            //Debug输出消息
            if (msg.type == MessageType.Debug)
            {
                Debug.Log("正在游戏");
            }
            //场景跳转类
            if (msg.type == MessageType.SceneLoad)
            {
                //跳转场景
                SceneManager.LoadScene(PageNumber);

            }
            

        }
    }

}
