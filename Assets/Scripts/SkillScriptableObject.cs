using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Create new skill")]
public class SkillScriptableObject : ScriptableObject
{
    // Информация о положении скилла в дереве скиллов
    public Skill TreeParent;
    public List<Skill> TreeChildren;
    // Информация об умении
    public string Name;
    public Sprite Icon;
    public int Cost;
    public int Cooldown;
    public int Damage;

    // Визуальные параметры умения
    public PhysicsMaterial2D Form;
    public Sprite Sprite;
    public int AnimationLengthSeconds;
    // Other Params
}
