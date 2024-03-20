using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Skill : MonoBehaviour
{
    // Информация об умении
    public string Name;
    public Sprite Icon;
    public float Cost;
    public float Cooldown;
    public float Damage;

    protected Vector3 scale;
    protected Vector3 initialPositionOffset;

    // Дополнительные эффекты (слабость, яд)
    // ???

    // Визуальные параметры умения
    // Сюда нужно вставить форму умения (MeshCollider for SkillInstance)
    public float AnimationLengthSeconds;
    // Other Params

    public virtual void Start()
    {
        
    }

    protected abstract void AffectTheTarget(CharacterInstance character);
}
