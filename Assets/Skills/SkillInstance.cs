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
        CharacterInstance characterHit;
        if (other.TryGetComponent<CharacterInstance>(out characterHit))
        {
            characterHit.GetHitBySkill(SkillInfo);
        }
    }

    public void SetSkillInfo(Skill Skill)
    {
        SkillInfo = Skill;
    }
}
