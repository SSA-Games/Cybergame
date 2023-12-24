using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    public float Health;
    public float Energy;
    public float[] Position = new float[3];
    public string LevelName;

    public List<Item> Inventory = new List<Item>();
    public List<Skill> AcquiredSkills = new List<Skill>();

    public SaveData(GameObject player)
    {
        Position[0] = player.transform.position.x;
        Position[1] = player.transform.position.y;
        Position[2] = player.transform.position.z;

        LevelName = player.scene.name;

        PlayerInstance playerInstance = player.GetComponent<PlayerInstance>();
        Inventory = playerInstance.Inventory;
        AcquiredSkills = playerInstance.AcquiredSkills;
    }
}