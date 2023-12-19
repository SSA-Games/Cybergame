using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInstance : CharacterInstance
{
    private List<GameObject> interactableObjects = new List<GameObject>();
    private GameObject closestInteractableObject;

    public List<Item> Inventory = new List<Item>();
    public Skill[] skillSlots = new Skill[3];

    private void Start()
    {
        //DEBUG
        AcquiredSkills.Add(FindSkillByName("Pantheon Q DEBUG"));
        ChangeSkillSlot(0, FindSkillByName("Pantheon Q DEBUG"));
        //DEBUG
    }

    protected override void Update()
    {
        base.Update(); // Check if we are dead

        // ���������� ���������� �� �������� � InteractableObjects
        foreach(GameObject obj in interactableObjects)
        {
            if (Vector3.Distance(transform.position, obj.transform.position) < Vector3.Distance(transform.position, closestInteractableObject.transform.position))
            {
                closestInteractableObject = obj;
            }
        }
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

    public void Interact() // �� ��������������� � ��������� ��������� �� ������ ���������
    {
        if(closestInteractableObject != null)
        {
            ItemInstance item;
            NPCInstance NPC;
            if (closestInteractableObject.TryGetComponent<ItemInstance>(out item))
            {
                //������ ��������
                Inventory.Add(item.GetItemInfo());
                Destroy(closestInteractableObject);
            }
            else if (closestInteractableObject.TryGetComponent<NPCInstance>(out NPC))
            {
                //������������� � NPC
                GameObject[] participants = new GameObject[2] { this.gameObject, closestInteractableObject };
                Dialog dialog = new Dialog(participants, 0); // ����� ��������: ��� ���������� ����� �� ����� ������??
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
            interactableObjects.Add(item.gameObject);
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
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (interactableObjects.Contains(collision.gameObject))
        {
            interactableObjects.Remove(collision.gameObject);
        }
    }
}
