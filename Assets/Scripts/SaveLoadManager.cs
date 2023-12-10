using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class SaveLoadManager : MonoBehaviour
{
    public GameObject Player;
    private string path;
    private DirectoryInfo folder;
    private void Start()
    {
        path = Application.persistentDataPath;
        folder = new DirectoryInfo(path + "/saves");
    }
    public void QuickSave()
    {
        //Выбираем имя файла
        string name = "/save0.json";
        while (File.Exists(path + "/saves" + name))
        {
            name = "/save" + (Convert.ToInt32(name[5]) + 1).ToString() + ".json";
        }
        //Сохраняем
        PlayerData data = new PlayerData(Player);
        string json = JsonUtility.ToJson(data, true);
        if (!folder.Exists)
        {
            folder.Create();
        }
        File.WriteAllText(path + "/saves" + name, json);
    }
    
    public void Load(string name) //Загрузка сохранения
    {
        string json = File.ReadAllText(path + "/saves/" + name + ".json");
        PlayerData data = JsonUtility.FromJson<PlayerData>(json);

        Player.transform.position = new Vector3(data.position[0], data.position[1], data.position[2]);
    }

    public int SavesCount() //Получение количества файлов сохранений
    {
        if (folder.Exists)
        {
            return folder.GetFileSystemInfos().Length;
        }
        return 0;
    }

    public List<string> GetSaveNames() //Получение имеющихся сохранений для меню LoadGameUI
    {
        List<string> result = new List<string>();
        if (folder.Exists)
        {
            foreach(var element in folder.GetFiles())
            {
                result.Add(element.Name);
            }
        }
        return result;
    }
}
