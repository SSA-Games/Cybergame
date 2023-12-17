using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SkillInstance : MonoBehaviour
{
    Skill SkillInfo;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        try
        {
            collision.gameObject.GetComponent<Character>().GetHitBySkill(SkillInfo);
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
