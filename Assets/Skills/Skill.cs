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
public enum SkillType { 
    HACK,                   // Целеуказание: по всем в радиусе, либо мышью (при замедлении времени?). Применение эффектов/смена поведения объектов на карте (не только врагов)
    CLOSE_RANGE,            // Удар чем-либо. Создается объект с коллайдером и анимацией в направлении удара.
    HIGH_RANGE              // Скиллшот. Создается движущийся объект с коллайдером и анимацией, направленный в точку курсора
}
