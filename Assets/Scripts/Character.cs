using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    GameManager gm;
    public string Name;
    public int Health;
    public int Energy;

    public Skill[] skillSlots = new Skill[3];
    private void Awake()
    {
        gm = GameObject.Find("Game Manager").GetComponent<GameManager>();

        Health = 300;
        Energy = 100;
        Name = "John Doe";
    }
    // Поиск в списке по имени-------
    protected Skill FindSkillByName(string name)
    {
        foreach(Skill skill in gm.SkillList)
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

    public void ChangeSkillSlot(int slotNumber, Skill skill)
    {
        skillSlots[slotNumber] = skill;
    }
}

