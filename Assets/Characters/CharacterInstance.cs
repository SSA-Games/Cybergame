using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class CharacterInstance : MonoBehaviour
{
    public List<Skill> AcquiredSkills;
    public string Name = "CHARACTER_NAME";
    public float Health;
    public float Energy;
    public bool invulnurable = false; // Проходят ли по персонажу попадания (ставить true для NPC)

    protected virtual void Update()
    {
        if (Health <= 0)
        {
            Destroy(gameObject); // 死
        }
    }

    public void CastSkill(Skill skill)
    {
        Energy -= skill.Cost;
        //Создание и инстанцирование GameObject из Skill ScriptableObject
        GameObject skillGameObject = new GameObject("skillGameObject");
        skillGameObject.transform.position = this.gameObject.transform.position + (Vector3)PlayerControl.ViewDirection;
        skillGameObject.transform.localScale = skill.Size;
        skillGameObject.transform.SetParent(this.gameObject.transform);

        var Collider = skillGameObject.AddComponent<BoxCollider2D>();          // Позже надо заменить на MeshCollider
        var SpriteRenderer = skillGameObject.AddComponent<SpriteRenderer>();
        var SkillScript = skillGameObject.AddComponent<SkillInstance>();
        SkillScript.SkillConstruct(skill);

        Collider.size = new Vector2(skill.Size.x / (float)36.8125, skill.Size.y / (float)36.8125);
        Collider.isTrigger = true;
        SpriteRenderer.sprite = skill.Sprite;
        Destroy(skillGameObject, skill.AnimationLengthSeconds);
    }

    public void GetHitBySkill(Skill skill)
    {
        if (!invulnurable)
        {
            Health -= skill.Damage;
        }
    }

    // Поиск умения в списке приобритенных умений (по имени) -------
    protected Skill FindSkillByName(string name)
    {
        foreach (Skill skill in AcquiredSkills)
        {
            if (skill.name == name)
            {
                return skill;
            }
        }
        Debug.Log("Couldn't find the skill in list");
        return null;
    }
    // -------------------------------------------------------------
}
