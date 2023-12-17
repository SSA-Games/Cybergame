using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Linq;
using UnityEngine.SceneManagement;

public static class SaveLoadManager
{
    public static string path;
    private static DirectoryInfo folder;
    public static PlayerSaveData LoadedPlayerData;
    static SaveLoadManager()
    {
        path = Application.persistentDataPath;
        folder = new DirectoryInfo(path + "/saves");
        if (!folder.Exists)
        {
            folder.Create();
        }
    }
    public static string QuickSave() //ВЫЗОВ ТОЛЬКО ИЗ УРОВНЯ
    {
        //Выбираем имя файла
        string name = "/save0.json";
        while (File.Exists(path + "/saves" + name))
        {
            Debug.Log(name[5]);
            name = "/save" + (Convert.ToInt32(name[5]) + 1).ToString() + ".json";
        }
        //Находим игрока, чтобы взять у него данные
        GameObject player = SceneManager.GetActiveScene().GetRootGameObjects().Where(obj => obj.name == "Player").ToArray()[0];
        //Сохраняем
        PlayerSaveData data = new PlayerSaveData(player);
        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(path + "/saves" + name, json);
        return name.Substring(1, 5);
    }

    public static void LoadSave(string name) //Загрузка сохранения.
    {
        string json = File.ReadAllText(path + "/saves/" + name + ".json");
        LoadedPlayerData = JsonUtility.FromJson<PlayerSaveData>(json); //Получаем данные из файла
        SceneManager.LoadScene(LoadedPlayerData.level_name);
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

    public static void DeleteSave(string name)
    {
        File.Delete(Application.persistentDataPath + "/saves/" + name + ".json");
    }

}
