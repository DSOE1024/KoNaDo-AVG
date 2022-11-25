using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ������Ϣ����
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
    //Ĭ�϶Ի�����
    public MessageType type = MessageType.Message;
    //�����л�
    public string SceneLoad;
    //��Ƶϵͳ
    public string Audio;
    //BGM������
    public string BGM;
    //�Ի���ɫ����
    public string Name;
    //�Ի�����
    public string Content;
    //�Ի���ɫͼƬ
    public string ImageName;
    //��������
    public string Background;

}
