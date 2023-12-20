using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInstance : MonoBehaviour
{
    private Item ItemInfo;
    private Vector3 position;

    private void Awake()
    {
        tag = "Item";
        transform.parent = null;
    }
    private void Start()
    {
        float heightCorrection = 0.1f;
        transform.position = new Vector3(position.x, position.y + heightCorrection, position.z);
        GetComponent<SpriteRenderer>().sprite = ItemInfo.Sprite;
    }
    public void FixedUpdate()
    {
        transform.position = GetCurrrentPosition();
    }

    private Vector2 GetCurrrentPosition()
    {
        float frequency = 2.5f;
        float amplitude = 0.004f;
        return new Vector2(transform.position.x, transform.position.y + amplitude * Mathf.Sin(frequency * Time.time));
    }

    public void SetItemInfo(Item item, Vector3 position)
    {
        this.position = position;
        ItemInfo = item;
    }

    public Item GetItemInfo()
    {
        return ItemInfo;
    }
}
