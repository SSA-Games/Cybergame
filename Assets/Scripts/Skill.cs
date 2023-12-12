using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Skill : MonoBehaviour
{
    SkillScriptableObject SkillInfo;
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

    public void SkillConstruct(SkillScriptableObject skillScriptableObject)
    {
        SkillInfo = skillScriptableObject;
    }
}
