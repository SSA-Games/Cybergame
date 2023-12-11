using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Create new skill")]
public class Skill : ScriptableObject
{
    // Информация о положении скилла в дереве скиллов
    public Skill TreeParent;
    public List<Skill> TreeChildren;
    //
    public string Name;
    public Sprite Icon;
    public int Cost;
    public int Cooldown;

    public CustomCollider2D Collider;
    public int AnimationLengthSeconds;
    // Other Params
}
