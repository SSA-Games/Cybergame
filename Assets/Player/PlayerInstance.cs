using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInstance : CharacterInstance
{
    public Skill[] skillSlots = new Skill[3];
    private void Start()
    {
        //DEBUG
        AcquiredSkills.Add(FindSkillByName("Pantheon Q DEBUG"));
        ChangeSkillSlot(0, FindSkillByName("Pantheon Q DEBUG"));
        //DEBUG
    }

    public void ChangeSkillSlot(int slotNumber, Skill skill)
    {
        if (AcquiredSkills.Contains(skill))
        {
            skillSlots[slotNumber] = skill;
        }
        else
        {
            Debug.Log("You can't insert a skill you haven't acquired");
        }
    }
}
