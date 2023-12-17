using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public List<Skill> AcquiredSkills;
    public string Name;
    public int Health;
    public int Energy;

    private void Awake()
    {
        Health = 300;
        Energy = 100;
        Name = "John Doe";
    }

    protected virtual void Update()
    {
        if (Health <= 0)
        {
            // Смэрть (Destroy gameobject)
        }
    }
    // Поиск в списке по имени-------
    protected Skill FindSkillByName(string name)
    {
        foreach(Skill skill in AcquiredSkills)
        {
            if (skill.name == name)
            {
                return skill;
            }
        }
        Debug.Log("Couldn't find the skill in list");
        return null;
    }
    // ------------------------------
    public void CastSkill(Skill skill)
    {
        Energy -= skill.Cost;
        //Создание и инстанцирование GameObject из Skill ScriptableObject
        GameObject skillGameObject = new GameObject("skillGameObject");
        skillGameObject.transform.position = this.gameObject.transform.position + (Vector3)PlayerControl.viewDirection;
        skillGameObject.transform.SetParent(this.gameObject.transform);
        var Collider = skillGameObject.AddComponent<CustomCollider2D>();
        var SpriteRenderer = skillGameObject.AddComponent<SpriteRenderer>();
        var SkillScript = skillGameObject.AddComponent<SkillInstance>();
        SkillScript.SkillConstruct(skill);

        Collider.sharedMaterial = skill.Form;
        Collider.isTrigger = true;
        SpriteRenderer.sprite = skill.Sprite;
        Destroy(skillGameObject, skill.AnimationLengthSeconds);
    }

    public void GetHitBySkill(Skill skill)
    {
        Health -= skill.Damage;
    }

}

