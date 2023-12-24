using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class CharacterInstance : MonoBehaviour
{
    public List<Skill> AcquiredSkills; // Список скиллов, которыми обладает персонаж
    public string Name = "CHARACTER_NAME";
    public float Health;
    public float Energy;

    // Флаги состояния персонажа
    public bool Invulnurable = false; // Проходят ли по персонажу попадания (ставить true для NPC не в бою)
    public bool Talkable = false; // Можно ли поговорить с персонажем
    public bool InBattle = false; 
    public bool InDialog = false; // Находится ли персонаж в диалоге (нужно для управления персонажем)

    protected GameObject Target; // Цель в бою
    public GameObject skillPrefab; // Экземпляр пустого скилла.

    protected DialogManager dm;

    protected virtual void Start()
    {
        dm = GameObject.Find("GameManager").GetComponent<DialogManager>(); // Доступ к менеджеру диалогов
    }
    protected virtual void Update() 
    {
        if (Health <= 0) // Проверка на смерть
        {
            Die();
        }
    }

    public void CastSkill(Skill skill)
    {
        Energy -= skill.Cost;

        switch (skill.Type) {                   // Позже изменю чтобы было покрасивее
            case SkillType.CLOSE_RANGE:
                // Инстанцирование префаба скилла skill
                GameObject skillGameObject = Instantiate(skillPrefab);
                skillGameObject.transform.position = this.gameObject.transform.position + (Vector3)PlayerControl.ViewDirection;
                skillGameObject.transform.localScale = skill.Size;
                skillGameObject.transform.SetParent(this.gameObject.transform);

                skillGameObject.GetComponent<SkillInstance>().SetSkillInfo(skill);
                break;
            case SkillType.HACK:
                /* 
                 * Что должен уметь делать любой скрипт Hack?
                 * Выбирать для себя цели (по всей карте или ту, что под мышкой)
                 * Применять эффект на цели.
                 * Не нужно создавать GameObject
                 */
                break;
        }
    }

    public void GetHitBySkill(Skill skill) // При попадании по объекту скилла, вызвать эту функцию
    {
        if (!Invulnurable)
        {
            Health -= skill.Damage;
        }
    }

    public virtual void Die()
    {
        Destroy(gameObject); // 死
    }

    // Поиск умения в списке приобретенных умений (по имени) -------
    protected Skill GetAcquiredSkillByName(string name)
    {
        foreach (Skill skill in AcquiredSkills)
        {
            if (skill.name == name)
            {
                return skill;
            }
        }
        Debug.Log("Couldn't find the skill in list of acquired skills");
        return null;
    }

    // -------------------------------------------------------------
}
