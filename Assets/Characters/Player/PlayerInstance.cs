using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInstance : CharacterInstance
{
    private List<GameObject> interactableObjects = new List<GameObject>();
    private GameObject closestInteractableObject;

    public List<Item> Inventory = new List<Item>();

    protected override void Start()
    {
        base.Start();

        // Stats initialization:
        Health = 200;
        MaxHealth = 200;
        HealthRegen = 0.1f;
        Energy = 100;
        MaxEnergy = 100;
        EnergyRegen = 0.1f; 
    }

    protected void FixedUpdate()
    {
        if (Health < MaxHealth)
        {
            Health += HealthRegen;
        }
        if (Energy < MaxEnergy)
        {
            Energy += EnergyRegen;
        }
    }
    protected override void Update()
    {
        base.Update(); // Check if we are dead


        // ���������� ���������� �� �������� � InteractableObjects (�� ������ ��������������� � ���������)
        foreach(GameObject obj in interactableObjects)
        {
            if (Vector3.Distance(transform.position, obj.transform.position) < Vector3.Distance(transform.position, closestInteractableObject.transform.position))
            {
                closestInteractableObject = obj;
            }
        }
    }

    public void Interact() // �� ��������������� � ��������� ��������� �� ������ ���������
    {
        if (closestInteractableObject != null) // ���� ����� ������
        {
            if (closestInteractableObject.tag == "NPC") // ���� ������ - NPC
            {
                //������������� � NPC
                InDialog = true;
                NPCInstance NPC = closestInteractableObject.GetComponent<NPCInstance>();
                GameObject[] participants = new GameObject[2] { this.gameObject, closestInteractableObject };
                dm.InitiateDialog(participants, 0);
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D collision) // ��� ����� � ������ ���������������
    {
        Debug.Log("Something entered the trigger");
        ItemInstance item;
        NPCInstance NPC;
        // ���� ������������ �������, NPC, ��� �������, ��������� � ������ ��������� ��� ��������������
        if (collision.TryGetComponent<ItemInstance>(out item))
        {
            Debug.Log("Item detected!");
            //������ ��������
            Inventory.Add(item.GetItemInfo());
            Destroy(item.gameObject);
        }
        else if (collision.TryGetComponent<NPCInstance>(out NPC))
        { 
            if (NPC.Talkable)  //���������, ����� �� � NPC ��������
            {
                interactableObjects.Add(NPC.gameObject);
            }
        }
        if (interactableObjects.Count == 1)
        {
            closestInteractableObject = interactableObjects[0];
        }
    }
    private void OnTriggerExit2D(Collider2D collision) // ��� ������ ������� �� ������� ���������������
    {
        // ���� ��, ��� ��� �������� ���� � ������ �������� ��� ��������������, ������� ������.
        if (interactableObjects.Contains(collision.gameObject))
        {
            interactableObjects.Remove(collision.gameObject);
        }
    }
}
