using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Create new Item/Device")]
public class DeviceItem : Item
{
    public short HackDifficulty // Варьируется от 0 до 4
    {
        get
        {
            return HackDifficulty; 
        } 
        set
        {
            if (value > 4)
            {
                HackDifficulty = 4;
            } else if (value < 0)
            {
                HackDifficulty = 0;
            }
            else
            {
                HackDifficulty = value;
            }
        }
    }

    public List<Item> ItemRewards = new List<Item>();
}
