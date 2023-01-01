using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu()]
public class AVGData : ScriptableObject
{
    //序列化数据
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
    //控制角色显示
    public bool CharaADisplay;
    public bool CharaBDisplay;
    //BGM
    public AudioClip BgmAudio;
    //配音
    public AudioClip CharaAudio;
    //对话速度
    [Range(1, 100)]
    public float DialogSpeed = 10;
    //是否选择
    public bool Ischoice;
    //选项文字
    public string BtAText;
    public string BtBText;

    //选项剧情跳转
    public string BtAmsg;
    public string BtBmsg;
    //下一个场景序号
    public int NextSceneNum;
}
