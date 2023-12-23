using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private GameObject player;
    private PlayerSaveData data;
    void Awake()
    {
        if (SaveLoadManager.LoadedPlayerData != null)
        {
            data = SaveLoadManager.LoadedPlayerData;
            player = GameObject.Find("Player");

            //«агрузка данных
            player.transform.position = new Vector3(data.position[0], data.position[1], data.position[2]);

            SaveLoadManager.LoadedPlayerData = null; // ќбнул€ем использованные данные (по сути служат маркером загрузки)
        }
        // Initial conditions
        Time.timeScale = 1f;
    }
}
