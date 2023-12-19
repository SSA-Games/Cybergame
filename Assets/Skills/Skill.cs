using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Create new skill")]
public class Skill : ScriptableObject
{
    // Информация об умении
    public Sprite Icon;
    public float Cost;
    public float Cooldown;
    public float Damage;
    public SkillType Type;
    public Vector2 Size;

    // Дополнительные эффекты (слабость, яд)
    // ???

    // Визуальные параметры умения
    // Сюда нужно вставить форму умения (MeshCollider for SkillInstance)
    public Sprite Sprite;
    public float AnimationLengthSeconds;
    // Other Params

}
public enum SkillType { HACK, CLOSE_RANGE, HIGH_RANGE_DOT, HIGH_RANGE_DIRECTIONAL }
