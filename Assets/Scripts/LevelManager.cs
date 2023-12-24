using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private SaveData data;
    private PlayerInstance player;
    void Awake()        // При загрузке уровня:
    {
        if (SaveLoadManager.LoadedPlayerData != null)
        {
            data = SaveLoadManager.LoadedPlayerData;
            player = GameObject.Find("Player").GetComponent<PlayerInstance>();

            //Загрузка данных
            player.transform.position = new Vector3(data.Position[0], data.Position[1], data.Position[2]);

            player.Health = data.Health;
            player.Energy = data.Energy;
            player.Inventory = data.Inventory;
            player.AcquiredSkills = data.AcquiredSkills;

            SaveLoadManager.LoadedPlayerData = null; // Обнуляем использованные данные (по сути служат маркером загрузки)
        }
        // Initial conditions
        Time.timeScale = 1f;
    }
}
