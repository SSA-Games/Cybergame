using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private GameObject player;
    private PlayerData data;
    void Awake()
    {
        if (SaveLoadManager.LoadedPlayerData != null)
        {
            data = SaveLoadManager.LoadedPlayerData;
            player = GameObject.Find("Player");

            //�������� ������
            player.transform.position = new Vector3(data.position[0], data.position[1], data.position[2]);

            SaveLoadManager.LoadedPlayerData = null; // �������� �������������� ������ (�� ���� ������ �������� ��������)
        }
        // Initial pause conditions
        PauseControl.isPaused = false;
        Time.timeScale = 1f;
    }
}
