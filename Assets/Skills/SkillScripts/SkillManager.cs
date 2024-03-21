using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SkillManager : MonoBehaviour
{
    private CharacterInstance caster;
    public List<GameObject> Acquired_skills = new List<GameObject>(); //���� �������, ��������� ������� � UnityEngine
    public GameObject[] hotkey_skills = new GameObject[3];         //���� ���� � ������

    public void Start()
    {
        caster = gameObject.GetComponent<CharacterInstance>(); // Cc���� �� ������� ������
    }
    public void CastSkill(int hotkey_id)  //���� �� ���� ������ (�� ����� ���� �������� �� ��������)
    {
        // ������ ������ �������� �� ����
        Skill skill = hotkey_skills[hotkey_id].GetComponent<Skill>();
        caster.Energy -= skill.Cost;
        // ����� ������� ������
        Instantiate(hotkey_skills[hotkey_id], gameObject.transform);
        //����� ������ ���������� ���������� ���������� � ������� ������
    }

    public void CastSkill(string name)    //���� �� �������� ������, ��� ����������
    {
        foreach (GameObject skill in Acquired_skills)
        {
            if (skill.name == name)
            {
                // ������ ������ �������� �� ����
                Skill skill_script = skill.GetComponent<Skill>();
                caster.Energy -= skill_script.Cost;
                // ����� ������� �����
                Instantiate(skill, gameObject.transform);
                //����� ������ ���������� ���������� ���������� � ������� ������
                break;
            }
        }
    }

    public Skill GetSkillFromHotkey(int id)
    {
        return hotkey_skills[id].GetComponent<Skill>();
    }

    public void SetHotkey(int hotkey_id, GameObject skill_prefab)
    {
        hotkey_skills[hotkey_id] = skill_prefab;
    }

    public void AcquireSkill(Skill skill)
    {

    }
}

