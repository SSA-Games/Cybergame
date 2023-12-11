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
        GameObject skillGameObject = new GameObject("skillGameObject");

        skillGameObject.AddComponent<CustomCollider2D>();
    }
}
