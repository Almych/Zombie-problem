using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    [SerializeField] private PlayInventory inventory;
    private Dictionary<InventoryItem, InventorySlot> slots = new Dictionary<InventoryItem, InventorySlot>();

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    void OnDestroy()
    {
        
    }

    public void CreateInventory()
    {
        for (int i = 0; i < inventory.items.Length; i++)
        {
            if (inventory.items[i].item != null)
            CreateSlot(inventory.items[i]);
        }
    } 

    public void RemoveFromInventory(InventoryItem removeItem)
    {
        if (inventory.RemoveItem(removeItem))
        {
            InventorySlot removeSlot = slots[removeItem];
            slots.Remove(removeItem);
            Destroy(removeSlot.gameObject);
        }
    }

    public void AddToInventory(InventoryItem newInventoryItem)
    {
        if (inventory.AddItem(newInventoryItem))
        {
            CreateSlot(newInventoryItem);
        }
    }

    private void CreateSlot(InventoryItem inventoryItem)
    {
        InventorySlot slot = ObjectPoolManager.FindObject<InventorySlot>();
        slot.SetInventorySlot(inventoryItem);
        slots[inventoryItem] = slot;
    }
}
