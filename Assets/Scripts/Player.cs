using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    public List<Skill> AquiredSkills;
    private void Start()
    {
        //DEBUG
        ChangeSkillSlot(0, FindSkillByName("Pantheon Q DEBUG"));
        //DEBUG
    }
}
