using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class CharacterInstance : MonoBehaviour
{
    public string Name = "CHARACTER_NAME";
    public float Health;
    public float MaxHealth;
    public float HealthRegen;
    public float Energy;
    public float MaxEnergy;
    public float EnergyRegen;

    // Флаги состояния персонажа
    public bool Invulnurable = false; // Проходят ли по персонажу попадания (ставить true для NPC не в бою)
    public bool Talkable = false; // Можно ли поговорить с персонажем
    public bool InBattle = false; 
    public bool InDialog = false; // Находится ли персонаж в диалоге (нужно для управления персонажем)

    protected GameObject Target; // Цель в бою, для NPC

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


    public virtual void Die()
    {
        Destroy(gameObject); // 死
    }

}
