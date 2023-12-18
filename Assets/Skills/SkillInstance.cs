using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SkillInstance : MonoBehaviour
{
    Skill SkillInfo;
    public void Start()
    {
        GetComponent<BoxCollider2D>().size = new Vector2(SkillInfo.Size.x / (float)36.8125, SkillInfo.Size.y / (float)36.8125);
        GetComponent<SpriteRenderer>().sprite = SkillInfo.Sprite;
        Destroy(gameObject, SkillInfo.AnimationLengthSeconds);
    }

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

    public void SetSkillInfo(Skill Skill)
    {
        SkillInfo = Skill;
    }
}