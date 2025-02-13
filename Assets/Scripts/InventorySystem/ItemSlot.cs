using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public interface ICollectable
{
    void OnCollect();
}
public class ItemSlot : MonoBehaviour, ICollectable
{
    public SpriteRenderer spriteRenderer => GetComponent<SpriteRenderer>();
    [HideInInspector] public InventoryItem inventoryItem;
    
    public void Init(InventoryItem newInventoryItem)
    {
        inventoryItem = newInventoryItem;
        spriteRenderer.sprite = newInventoryItem.item.Sprite;
    }

    public void OnCollect()
    {
        if (inventoryItem != null)
        {
            InventoryManager.Instance.AddToInventory(inventoryItem);
            gameObject.SetActive(false);
        }
    }

}
