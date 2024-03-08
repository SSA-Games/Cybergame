using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Create new skill")]
public abstract class Skill
{
    // Информация об умении
    public string Name;
    public Sprite Icon;
    public float Cost;
    public float Cooldown;
    public float Damage;
    public Vector2 Size;

    // Дополнительные эффекты (слабость, яд)
    // ???

    // Визуальные параметры умения
    // Сюда нужно вставить форму умения (MeshCollider for SkillInstance)
    public Sprite Sprite;
    public float AnimationLengthSeconds;
    // Other Params

    public abstract void Cast(); // Здесь поместим логику конкретного скилла
}
