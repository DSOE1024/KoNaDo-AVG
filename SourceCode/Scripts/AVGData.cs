using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class AVGData : ScriptableObject
{
    //对话数据
    public List<DialogContent> contents;
    
}
[Serializable]

public class DialogContent
{
    //对话
    public string dialogText;
    //两个角色的图片
    public Texture CharaATex;
    public Texture CharaBTex;
    //背景图片
    public Texture BackGround;
    //两个角色的显示
    public bool CharaADisplay;
    public bool CharaBDisplay;
    //背景音乐BGM
    public AudioClip BgmAudio;
    //每句话的对话语音
    public AudioClip CharaAudio;
    //语速
    [Range(1, 100)]
    public float DialogSpeed = 10;
    //选择对话
    public bool Ischoice;
    //选项文字
    public string BtAText;
    public string BtBText;

    //按键选项名称
    public string BtAmsg;
    public string BtBmsg;
}
