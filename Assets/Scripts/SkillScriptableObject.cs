using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Create new skill")]
public class Skill : ScriptableObject
{
    // ���������� � ��������� ������ � ������ �������
    public Skill TreeParent;
    public List<Skill> TreeChildren;
    //
    public string Name;
    public Sprite Icon;
    public int Cost;
    public int Cooldown;

    public PhysicsMaterial2D Form;
    public Sprite Sprite;
    public int AnimationLengthSeconds;
    // Other Params
}
