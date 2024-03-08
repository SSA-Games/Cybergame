using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    public List<Skill> Aquired_skills = new List<Skill>(); //���� �������, ��������� ������� � UnityEngine
    private Skill[] hotkey_skills = new Skill[3];         //���� ���� � ������

    public void CastSkill(int hotkey_id)  //���� �� ���� ������ (�� ����� ���� �������� �� ��������)
    {
        hotkey_skills[hotkey_id].Cast();
    }

    public void CastSkill(string name)    //���� �� �������� ������, ��� ����������
    {
        foreach (Skill skill in Aquired_skills)
        {
            if (skill.Name == name)
            {
                skill.Cast();
                break;
            }
        }
    }

    public void SetHotkey(int hotkey_id, Skill skill)
    {
        hotkey_skills[hotkey_id] = skill;
    }

    public void AquireSkill(Skill skill)
    {

    }
}

