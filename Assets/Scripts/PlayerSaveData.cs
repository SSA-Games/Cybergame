using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerSaveData
{
    public float[] position = new float[3];
    public string level_name;

    public PlayerSaveData(GameObject player)
    {
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;

        level_name = player.scene.name;
    }
}