using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SkillManager : MonoBehaviour
{
    public List<GameObject> Acquired_skills = new List<GameObject>(); //Лист скиллов, добавляем объекту в UnityEngine
    public GameObject[] hotkey_skills = new GameObject[3];         //Есть лишь у игрока
   
    public void CastSkill(int hotkey_id)  //Каст по айди ячейки (мб потом айди заменить на название)
    {
        // Спавн объекта скилла
        Instantiate(hotkey_skills[hotkey_id], gameObject.transform);
        //После спавна управление меахниками происходит в скрипте скилла
    }

    public void CastSkill(string name)    //Каст по названию скилла, для алгоритмов
    {
        foreach (GameObject skill in Acquired_skills)
        {
            if (skill.name == name)
            {
                // Спавн объекта скила
                Instantiate(skill, gameObject.transform);
                //После спавна управление меахниками происходит в скрипте скилла
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

