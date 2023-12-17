using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Create new item")]
public class Item : ScriptableObject
{
    string Name;
    ItemType Type;
    public enum ItemType {DEVICE, SCRIPT_SHARD, CHIP_COMPONENT};
}
