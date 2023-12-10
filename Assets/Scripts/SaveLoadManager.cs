using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Linq;

public class SaveLoadManager : MonoBehaviour
{
    public GameObject Player;
    private static string path;
    private static DirectoryInfo folder;
    private void Start()
    {
        path = Application.persistentDataPath;
        folder = new DirectoryInfo(path + "/saves");
        if (!folder.Exists)
        {
            folder.Create();
        }
    }
    public void QuickSave()
    {
        //Выбираем имя файла
        string name = "/save0.json";
        while (File.Exists(path + "/saves" + name))
        {
            Debug.Log(name[5]);
            name = "/save" + (Convert.ToInt32(name[5]) + 1).ToString() + ".json";
        }
        //Сохраняем
        PlayerData data = new PlayerData(Player);
        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(path + "/saves" + name, json);
    }
    
    public void Load(string name) //Загрузка сохранения
    {
        string json = File.ReadAllText(path + "/saves/" + name + ".json");
        PlayerData data = JsonUtility.FromJson<PlayerData>(json);

        Player.transform.position = new Vector3(data.position[0], data.position[1], data.position[2]);
    }

    public static int SavesCount() //Получение количества файлов сохранений
    {
        if (folder.Exists)
        {
            return folder.GetFileSystemInfos().Length;
        }
        return 0;
    }

    public static List<string> GetSaveNames() //Получение имеющихся сохранений для меню LoadGameUI
    {
        List<string> result = new List<string>();
        if (SavesCount() != 0)
        {
            foreach (FileInfo element in folder.GetFiles())
            {
                result.Add(element.Name);
            }
        }
        return result;
    }
}
