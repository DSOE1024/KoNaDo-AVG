using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSaveManager : MonoBehaviour
{
    public EditorUIPanel uIPanel;
    public AVGMachine machine;
    //�浵����
    public string SaveDataName;
    //��ȡ����
    public string ReadDataName;
    // Start is called before the first frame update
    void Start()
    {
        //machine.ProcessSaveGame();
        //��ʼ��
        ReadDataName = null;
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
    //����浵
    public void SaveGameData()
    {
        machine.ProcessSaveGame();
        SaveDataName = machine.thisDataName;
        PlayerPrefs.SetString("GameSaves", SaveDataName);
        //ReadDataName = SaveDataName;
        Debug.Log("����浵");
    }
    //��ȡ�浵
    public void ReadGameData()
    {
        PlayerPrefs.GetString("GameSaves", null);
        ReadDataName = SaveDataName;
        PlayerPrefs.SetString("GameSavesRead",ReadDataName);
        PlayerPrefs.GetString("GameSavesRead", null);
        if (ReadDataName == null)
        {
            Debug.Log("����û�д浵");
        }
        else
        {
            Debug.Log("���ش浵");
            machine.ProcessReadGameSaves(ReadDataName);
        }
        //machine.ProcessReadGameSaves(ReadDataName);
    }

    //�Ƴ�
    public void ExitGameMenu()
    {
        Debug.Log("�˳�");
    }
}
