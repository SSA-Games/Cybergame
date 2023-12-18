using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class EnemyInstance : CharacterInstance
{
    public GameObject itemPrefab;
    public List<Item> LootList = new List<Item>();
    private void Awake()
    {
        FightModeTarget = GameObject.Find("Player");
    }
    protected override void Update()
    {
        base.Update();
        //Patrolling the area until seeing the player
        if (InBattle)
        {
            if (FightModeTarget != null) // Checking if target is not dead
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
        // Destroy itself
        base.Die();
    }
}
