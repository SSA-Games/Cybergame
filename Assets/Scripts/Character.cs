using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public string Name;
    public int Health;

    public Skill[] SkillSlots = new Skill[4];

    public void CastSkill(Skill skill)
    {
        //Создание и инстанцирование GameObject из Skill ScriptableObject
        GameObject skillGameObject = new GameObject("skillGameObject");

        var Collider = skillGameObject.AddComponent<CustomCollider2D>();
        var SpriteRenderer = skillGameObject.AddComponent<SpriteRenderer>();

        Collider.sharedMaterial = skill.Form;
        Collider.isTrigger = true;
        SpriteRenderer.sprite = skill.Sprite;
    }

    public void GetHitBySkill(Skill skill)
    {

    }
}
