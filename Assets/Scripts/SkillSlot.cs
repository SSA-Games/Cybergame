using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillSlot
{
    SkillScriptableObject Skill { get; set; };

    public void ChangeSkill(SkillScriptableObject skill)
    {
        this.skill = skill;
    }
}
