using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSaveManager : MonoBehaviour
{
    public EditorUIPanel uIPanel;
    public AVGMachine machine;
    //存档名称
    public string SaveDataName;
    //读取名称
    public string ReadDataName;
    // Start is called before the first frame update
    void Start()
    {
        //machine.ProcessSaveGame();
        //初始化
        ReadDataName = null;
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
    //保存存档
    public void SaveGameData()
    {
        machine.ProcessSaveGame();
        SaveDataName = machine.thisDataName;
        PlayerPrefs.SetString("GameSaves", SaveDataName);
        //ReadDataName = SaveDataName;
        Debug.Log("保存存档");
    }
    //读取存档
    public void ReadGameData()
    {
        PlayerPrefs.GetString("GameSaves", null);
        ReadDataName = SaveDataName;
        PlayerPrefs.SetString("GameSavesRead",ReadDataName);
        PlayerPrefs.GetString("GameSavesRead", null);
        if (ReadDataName == null)
        {
            Debug.Log("您还没有存档");
        }
        else
        {
            Debug.Log("加载存档");
            machine.ProcessReadGameSaves(ReadDataName);
        }
        //machine.ProcessReadGameSaves(ReadDataName);
    }

    //推出
    public void ExitGameMenu()
    {
        Debug.Log("退出");
    }
}
