using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPanel : MonoBehaviour
{
    //������ɫͼƬ
    public RawImage charaAImg;
    public RawImage charaBImg;
    //����ͼ
    public RawImage backgroundImg;
    //�Ի���
    public Image contentBg;
    //�Ի�
    public Text contentText;
    //����
    public Canvas canvas;
    //����ѡ��
    public GameObject BtA;
    public GameObject BtB;
    //AutoPlay��ť
    public Button AutoPlayBtn;
    //Stop��ť
    public Button AutoStopBtn;
    //ֹͣ����һ��
    public Button NextBtn;

    //��ʾ����
    public void ShowCanvas(bool value)
    {
        canvas.enabled = value;
    }

    //����ͼ
    public void ShowBackGround(Texture tex)
    {
        backgroundImg.texture = tex;
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

    //AutoPlay��ť
    public void ShowAutoPlayButton(bool value)
    {
        AutoPlayBtn.gameObject.SetActive(value);
        
    }
    //StopAutoPlay��ť
    public void ShowStopAutoButton(bool value)
    {
       
        AutoStopBtn.gameObject.SetActive(value);
    }

    //ֹͣ����һ��
    public void ShowNextSceneBtn(bool value)
    {
        NextBtn.gameObject.SetActive(value);

    }

}
