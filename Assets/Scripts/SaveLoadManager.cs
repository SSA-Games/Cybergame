using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Linq;
using UnityEngine.SceneManagement;

public class SaveLoadManager : MonoBehaviour
{
    public GameObject PlayerPrefab;
    private static string path;
    private static DirectoryInfo folder;
    private void Awake()
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
        //�������� ��� �����
        string name = "/save0.json";
        while (File.Exists(path + "/saves" + name))
        {
            Debug.Log(name[5]);
            name = "/save" + (Convert.ToInt32(name[5]) + 1).ToString() + ".json";
        }
        //���������
        PlayerData data = new PlayerData(gameObject);
        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(path + "/saves" + name, json);
    }

    public void Load(string name) //�������� ����������
    {
        string json = File.ReadAllText(path + "/saves/" + name + ".json");
        PlayerData data = JsonUtility.FromJson<PlayerData>(json); //�������� ������ �� �����

        SceneManager.LoadScene("Level_1"); //����� ���� �������� ���� ������ �������
        if (gameObject.name == "Player") //���������, ������ ���� ��� ������ � �������� ������ ��������
        {
            gameObject.transform.position = new Vector3(data.position[0], data.position[1], data.position[2]);
        }
        else
        {
            Instantiate(PlayerPrefab, new Vector3(data.position[0], data.position[1], data.position[2]), Quaternion.identity);
        }
    }
    public static int SavesCount() //��������� ���������� ������ ����������
    {
        if (folder.Exists)
        {
            return folder.GetFileSystemInfos().Length;
        }
        return 0;
    }

    public static List<string> GetSaveNames() //��������� ��������� ���������� ��� ���� LoadGameUI
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
