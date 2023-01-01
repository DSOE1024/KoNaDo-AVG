using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPanel : MonoBehaviour
{
    //两个角色图片
    public RawImage charaAImg;
    public RawImage charaBImg;
    //背景图
    public RawImage backgroundImg;
    //对话栏
    public Image contentBg;
    //对话
    public Text contentText;
    //画布
    public Canvas canvas;
    //两个选项
    public GameObject BtA;
    public GameObject BtB;
    //AutoPlay按钮
    public Button AutoPlayBtn;
    //Stop按钮
    public Button AutoStopBtn;
    //停止并下一个
    public Button NextBtn;

    //显示画布
    public void ShowCanvas(bool value)
    {
        canvas.enabled = value;
    }

    //背景图
    public void ShowBackGround(Texture tex)
    {
        backgroundImg.texture = tex;
    }
    //角色A
    public void ShowCharA(bool value)
    {
        charaAImg.enabled = value;
    }
    //角色B
    public void ShowCharB(bool value)
    {
        charaBImg.enabled = value;
    }

    //显示对话框
    public void ShowContent(bool value)
    {
        contentBg.enabled = value;
    }
    //显示对话
    public void ShowContentText(string value)
    {
        contentText.text = value;
    }
    //更改角色A的图片
    public void ChangeCharaATex(Texture tex)
    {
        charaAImg.texture = tex;
    }
    //更改角色B的图片
    public void ChangeCharaBTex(Texture tex)
    {
        charaBImg.texture = tex;
    }
    //显示选择按钮
    public void ShowButtons(bool value)
    {
        BtA.SetActive(value);
        BtB.SetActive(value);
    }
    //修改Button名称
    public void SetButtonNames(string nameA,string nameB)
    {
        BtA.name = nameA;
        BtB.name = nameB;
    }
    //设置按钮选项的文字
    public void SetButtonTexts(string txtA,string txtB)
    {
        //获取子物体Text
        Text tempATxt = BtA.GetComponentInChildren<Text>();
        tempATxt.text = txtA;
        Text tempBTxt = BtB.GetComponentInChildren<Text>();
        tempBTxt.text = txtB;

    }

    //AutoPlay按钮
    public void ShowAutoPlayButton(bool value)
    {
        AutoPlayBtn.gameObject.SetActive(value);
        
    }
    //StopAutoPlay按钮
    public void ShowStopAutoButton(bool value)
    {
       
        AutoStopBtn.gameObject.SetActive(value);
    }

    //停止并下一个
    public void ShowNextSceneBtn(bool value)
    {
        NextBtn.gameObject.SetActive(value);

    }

}
