using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class EnemyInstance : CharacterInstance
{
    // БАЗОВЫЙ КЛАСС ВРАГА
    public GameObject itemPrefab;
    public List<Item> LootList = new List<Item>();
    private void Awake()
    {
        Target = GameObject.Find("Player"); // По умолчанию, цель - игрок
    }

    // ЗДЕСЬ БУДЕТ НАХОДИТЬСЯ УНИВЕРСАЛЬНАЯ БОЕВАЯ ЛОГИКА ВРАГОВ.
    protected override void Update()
    {
        base.Update();
        //Patrolling the area until seeing the player
        if (InBattle)
        {
            if (Target != null) // Checking if target is not dead
            {
                AttackTarget();
            }
            else                         //If target is dead, return to patrolling
            {
                InBattle = false;
            }
        }
        else
        {
            CheckForTarget();
        }
    }

    protected virtual void CheckForTarget()
    {
        //Вероятно, у них будут какие-то области обзора. У каждого - своя.
        //If target discovered, set InBattle = true
    }

    protected virtual void AttackTarget()
    {
        // Battle logic. To be overwritten for each character.
    }

    public override void Die()
    {
        // Drop items on death
        foreach (Item loot in LootList)
        {
            float roll = Random.Range(0, 100);
            if (roll <= loot.DropChance)
            {
                GameObject itemInstance = Instantiate(itemPrefab);
                itemInstance.GetComponent<ItemInstance>().SetItemInfo(loot, transform.position);
                Debug.Log("Item dropped!");
            }
        }
        // Finally, die
        base.Die();
    }
}
