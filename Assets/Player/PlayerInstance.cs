using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInstance : CharacterInstance
{
    private List<GameObject> interactableObjects = new List<GameObject>();
    private GameObject closestInteractableObject;
    private Dialog dialog;

    public List<Item> Inventory = new List<Item>();
    public Skill[] skillSlots = new Skill[3];

    protected void Start()
    {
        Debug.Log("1) ����� ���-�� ������� � ��������������� ��������. ������ Rigidbody � ���������� ���������� ���������?");
        Debug.Log("2) �������� ��������� �������� ���������� ��� ��������");
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
        if (closestInteractableObject != null)
        {
            if (closestInteractableObject.tag == "Item")
            {
                //������ ��������
                ItemInstance item = closestInteractableObject.GetComponent<ItemInstance>();
                Inventory.Add(item.GetItemInfo());
                Destroy(closestInteractableObject);
            }
            else if (closestInteractableObject.tag == "NPC")
            {
                //������������� � NPC
                InDialog = true;
                NPCInstance NPC = closestInteractableObject.GetComponent<NPCInstance>();
                GameObject[] participants = new GameObject[2] { this.gameObject, closestInteractableObject };
                dialog = new Dialog(participants, 0);
            }
        }
    }

    public void ContinueDialog()
    {
        dialog.Advance();
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
