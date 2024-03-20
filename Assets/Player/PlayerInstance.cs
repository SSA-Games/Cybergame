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
        Debug.Log("1) Нужно что-то сделать с детектированием объектов. Убрать Rigidbody и переделать управление движением?");
        Debug.Log("Если что, подбирать предметы и говорить на кнопочку F");
    }

    protected override void Update()
    {
        base.Update(); // Check if we are dead

        // Перерасчет расстояния до объектов в InteractableObjects (Мы всегда взаимодействуем с ближайшим)
        foreach(GameObject obj in interactableObjects)
        {
            if (Vector3.Distance(transform.position, obj.transform.position) < Vector3.Distance(transform.position, closestInteractableObject.transform.position))
            {
                closestInteractableObject = obj;
            }
        }
    }

    public void Interact() // Мы взаимодействуем с ближайшим предметом из нашего окружения
    {
        if (closestInteractableObject != null) // Если нашли объект
        {
            if (closestInteractableObject.tag == "Item") // Если объект - предмет
            {
                //Подбор предмета
                ItemInstance item = closestInteractableObject.GetComponent<ItemInstance>();
                Inventory.Add(item.GetItemInfo());
                Destroy(closestInteractableObject);
            }
            else if (closestInteractableObject.tag == "NPC") // Если объект - NPC
            {
                //Взимодействие с NPC
                InDialog = true;
                NPCInstance NPC = closestInteractableObject.GetComponent<NPCInstance>();
                GameObject[] participants = new GameObject[2] { this.gameObject, closestInteractableObject };
                dm.InitiateDialog(participants, 0);
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D collision) // При входе в радиус интерактивности
    {
        Debug.Log("Something entered the trigger");
        ItemInstance item;
        NPCInstance NPC;
        // Если детектирован предмет, NPC, или магазин, добавляем в список предметов для взаимодействия
        if (collision.TryGetComponent<ItemInstance>(out item))
        {
            interactableObjects.Add(item.gameObject);
        }
        else if (collision.TryGetComponent<NPCInstance>(out NPC))
        { 
            if (NPC.Talkable)  //Проверяем, можно ли с NPC говорить
            {
                interactableObjects.Add(NPC.gameObject);
            }
        }
        if (interactableObjects.Count == 1)
        {
            closestInteractableObject = interactableObjects[0];
        }
    }
    private void OnTriggerExit2D(Collider2D collision) // При выходе из радиуса интерактивности
    {
        // Если то, что нас покидает было в списке объектов для взаимодействия, удаляем оттуда.
        if (interactableObjects.Contains(collision.gameObject))
        {
            interactableObjects.Remove(collision.gameObject);
        }
    }
}
