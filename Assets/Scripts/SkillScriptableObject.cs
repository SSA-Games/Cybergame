using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Create new skill")]
public class Skill : ScriptableObject
{
    // ���������� �� ������
    public Sprite Icon;
    public int Cost;
    public int Cooldown;
    public int Damage;
    public SkillType Type;

    // ���������� ��������� ������
    public PhysicsMaterial2D Form;
    public Sprite Sprite;
    public float AnimationLengthSeconds;
    // Other Params

    public enum SkillType {HACK, CLOSE_RANGE, HIGH_RANGE_DOT, HIGH_RANGE_DIRECTIONAL}
}
