using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private SaveData data;
    private PlayerInstance player;
    void Awake()        // ��� �������� ������:
    {
        if (SaveLoadManager.LoadedPlayerData != null)
        {
            data = SaveLoadManager.LoadedPlayerData;
            player = GameObject.Find("Player").GetComponent<PlayerInstance>();

            //�������� ������
            player.transform.position = new Vector3(data.Position[0], data.Position[1], data.Position[2]);

            player.Health = data.Health;
            player.Energy = data.Energy;
            player.Inventory = data.Inventory;
            player.AcquiredSkills = data.AcquiredSkills;

            SaveLoadManager.LoadedPlayerData = null; // �������� �������������� ������ (�� ���� ������ �������� ��������)
        }
        // Initial conditions
        Time.timeScale = 1f;
    }
}
