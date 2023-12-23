using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Create new skill")]
public class Skill : ScriptableObject
{
    // ���������� �� ������
    public Sprite Icon;
    public float Cost;
    public float Cooldown;
    public float Damage;
    public SkillType Type;
    public Vector2 Size;

    // �������������� ������� (��������, ��)
    // ???

    // ���������� ��������� ������
    // ���� ����� �������� ����� ������ (MeshCollider for SkillInstance)
    public Sprite Sprite;
    public float AnimationLengthSeconds;
    // Other Params

}
public enum SkillType { 
    HACK,                   // ������������: �� ���� � �������, ���� ����� (��� ���������� �������?). ���������� ��������/����� ��������� �������� �� ����� (�� ������ ������)
    CLOSE_RANGE,            // ���� ���-����. ��������� ������ � ����������� � ��������� � ����������� �����.
    HIGH_RANGE              // ��������. ��������� ���������� ������ � ����������� � ���������, ������������ � ����� �������
}
