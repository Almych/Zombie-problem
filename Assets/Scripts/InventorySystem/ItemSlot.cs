using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IPointerClickHandler
{
    public SpriteRenderer spriteRenderer => GetComponent<SpriteRenderer>();
    public InventoryItem inventoryItem { get; private set; }
    public void Init(InventoryItem newInventoryItem)
    {
        inventoryItem = newInventoryItem;
        spriteRenderer.sprite = newInventoryItem.item.Sprite;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Clicked");
        InventoryManager.Instance.AddToInventory(inventoryItem);
        gameObject.SetActive(false);
    }
}
