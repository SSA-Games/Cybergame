using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public static SkillTree skillTree = new SkillTree();

    public string Name;
    public int Health;
    public int Memory;

    public SkillSlot[] skillSlots = new SkillSlot[4];

    public void CastSkill(SkillSlot skillSlot)
    {
        Memory -= skillSlot.skill.Cost;
        //Создание и инстанцирование GameObject из Skill ScriptableObject
        GameObject skillGameObject = new GameObject("skillGameObject");

        var Collider = skillGameObject.AddComponent<CustomCollider2D>();
        var SpriteRenderer = skillGameObject.AddComponent<SpriteRenderer>();
        var SkillScript = skillGameObject.AddComponent<Skill>();
        SkillScript.SkillConstruct(skillSlot.skill);

        Collider.sharedMaterial = skillSlot.Skill.Form;
        Collider.isTrigger = true;
        SpriteRenderer.sprite = skillSlot.Skill.Sprite;
    }

    public void GetHitBySkill(SkillScriptableObject skill)
    {
        Health -= skill.Damage;
    }
}
