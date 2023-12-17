using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SkillInstance : MonoBehaviour
{
    Skill SkillInfo;

    private void OnTriggerEnter2D(Collider2D other)
    {
        string mes = "I hit something... "; // FOR DEBUG
        try
        {
            other.GetComponent<CharacterInstance>().GetHitBySkill(SkillInfo);
            mes += "It's a character!"; // FOR DEBUG
            Debug.Log(mes); // FOR DEBUG
        }
        catch (UnityException e)
        {
            Debug.Log(e.Message);
        }
    }

    public void SkillConstruct(Skill Skill)
    {
        SkillInfo = Skill;
    }
}
