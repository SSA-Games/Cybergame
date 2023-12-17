using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class CharacterInstance : MonoBehaviour
{
    public List<Skill> AcquiredSkills;
    public string Name = "CHARACTER_NAME";
    public float Health;
    public float Energy;

    // Флаги состояния
    public bool Invulnurable = false; // Проходят ли по персонажу попадания (ставить true для NPC не в бою)
    public bool Talkable = false; // Можно ли поговорить с персонажем
    public bool InBattle = false;

    public GameObject FightModeTarget; // Цель в бою

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

        var SkillScript = skillGameObject.AddComponent<SkillInstance>();
        SkillScript.SetSkillInfo(skill);
    }

    public void GetHitBySkill(Skill skill)
    {
        if (!Invulnurable)
        {
            Health -= skill.Damage;
        }
    }

    public void Interact()
    {

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
