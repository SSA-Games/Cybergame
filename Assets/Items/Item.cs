using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Create new item")]
public class Item : ScriptableObject
{
    public ItemType Type;
    public float DropChance;
    public Sprite Sprite;

    public enum ItemType {DEVICE, SCRIPT_SHARD, CHIP_COMPONENT};
}
