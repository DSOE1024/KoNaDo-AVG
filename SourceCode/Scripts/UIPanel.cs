using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPanel : MonoBehaviour
{
    public RawImage charaAImg;
    public RawImage charaBImg;
    public Image contentBg;
    public Text contentText;
    //����
    public Canvas canvas;
    //������ť
    public GameObject BtA;
    public GameObject BtB;
    //��ʾ����
    public void ShowCanvas(bool value)
    {
        canvas.enabled = value;
    }
    //��ɫA
    public void ShowCharA(bool value)
    {
        charaAImg.enabled = value;
    }
    //��ɫB
    public void ShowCharB(bool value)
    {
        charaBImg.enabled = value;
    }
    //��ʾ�Ի���
    public void ShowContent(bool value)
    {
        contentBg.enabled = value;
    }
    //��ʾ�Ի�
    public void ShowContentText(string value)
    {
        contentText.text = value;
    }
    //���Ľ�ɫA��ͼƬ
    public void ChangeCharaATex(Texture tex)
    {
        charaAImg.texture = tex;
    }
    //���Ľ�ɫB��ͼƬ
    public void ChangeCharaBTex(Texture tex)
    {
        charaBImg.texture = tex;
    }
    //��ʾѡ��ť
    public void ShowButtons(bool value)
    {
        BtA.SetActive(value);
        BtB.SetActive(value);
    }
    //�޸�Button����
    public void SetButtonNames(string nameA,string nameB)
    {
        BtA.name = nameA;
        BtB.name = nameB;
    }
    //���ð�ťѡ�������
    public void SetButtonTexts(string txtA,string txtB)
    {
        //��ȡ������Text
        Text tempATxt = BtA.GetComponentInChildren<Text>();
        tempATxt.text = txtA;
        Text tempBTxt = BtB.GetComponentInChildren<Text>();
        tempBTxt.text = txtB;

    }
}
