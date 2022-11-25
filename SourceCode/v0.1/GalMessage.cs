using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 剧情消息类型
/// </summary>
public enum MessageType
{
    Message,
    Background,
    BGM,
    Debug,
    SceneLoad
}

public class Message
{
    //默认对话类型
    public MessageType type = MessageType.Message;
    //场景切换
    public string SceneLoad;
    //音频系统
    public string Audio;
    //BGM背景乐
    public string BGM;
    //对话角色姓名
    public string Name;
    //对话内容
    public string Content;
    //对话角色图片
    public string ImageName;
    //场景背景
    public string Background;

}
