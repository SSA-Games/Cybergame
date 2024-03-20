using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Skill : MonoBehaviour
{
    // ���������� �� ������
    public string Name;
    public Sprite Icon;
    public float Cost;
    public float Cooldown;
    public float Damage;

    protected Vector3 scale;
    protected Vector3 initialPositionOffset;

    // �������������� ������� (��������, ��)
    // ???

    // ���������� ��������� ������
    // ���� ����� �������� ����� ������ (MeshCollider for SkillInstance)
    public float AnimationLengthSeconds;
    // Other Params

    public virtual void Start()
    {
        
    }

    protected abstract void AffectTheTarget(CharacterInstance character);
}
