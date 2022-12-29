using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class AVGData : ScriptableObject
{
    //�Ի�����
    public List<DialogContent> contents;
    
}
[Serializable]

public class DialogContent
{
    //�Ի�
    public string dialogText;
    //������ɫ��ͼƬ
    public Texture CharaATex;
    public Texture CharaBTex;
    //����ͼƬ
    public Texture BackGround;
    //������ɫ����ʾ
    public bool CharaADisplay;
    public bool CharaBDisplay;
    //��������BGM
    public AudioClip BgmAudio;
    //ÿ�仰�ĶԻ�����
    public AudioClip CharaAudio;
    //����
    [Range(1, 100)]
    public float DialogSpeed = 10;
    //ѡ��Ի�
    public bool Ischoice;
    //ѡ������
    public string BtAText;
    public string BtBText;

    //����ѡ������
    public string BtAmsg;
    public string BtBmsg;
}
