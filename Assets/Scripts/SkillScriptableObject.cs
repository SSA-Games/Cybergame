using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Create new skill")]
public class Skill : ScriptableObject
{
    // Информация об умении
    public Sprite Icon;
    public int Cost;
    public int Cooldown;
    public int Damage;
    public SkillType Type;

    // Визуальные параметры умения
    public PhysicsMaterial2D Form;
    public Sprite Sprite;
    public float AnimationLengthSeconds;
    // Other Params

    public enum SkillType {HACK, CLOSE_RANGE, HIGH_RANGE_DOT, HIGH_RANGE_DIRECTIONAL}
}
