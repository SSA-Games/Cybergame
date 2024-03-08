using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Create new skill")]
public abstract class Skill
{
    // ���������� �� ������
    public string Name;
    public Sprite Icon;
    public float Cost;
    public float Cooldown;
    public float Damage;
    public Vector2 Size;

    // �������������� ������� (��������, ��)
    // ???

    // ���������� ��������� ������
    // ���� ����� �������� ����� ������ (MeshCollider for SkillInstance)
    public Sprite Sprite;
    public float AnimationLengthSeconds;
    // Other Params

    public abstract void Cast(); // ����� �������� ������ ����������� ������
}
