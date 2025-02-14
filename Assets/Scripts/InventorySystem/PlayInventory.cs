using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New PlayInventory", menuName = "Inventory/PlayInventory")]
public class PlayInventory : ScriptableObject
{
    public InventoryItem[] items = new InventoryItem[5];  
    public Weapon[] weaponSlots = new Weapon[2];         
    public MainInventory mainInventory;                   

   
    public bool AddItem(InventoryItem newItem)
    {
       
        InventoryItem existingItem = FindItemInInventory(newItem);
        if (existingItem != null)
        {
            if (CanAddToStack(existingItem, 1))
            {
                existingItem.AddAmount();
                Debug.Log("Increased item amount in inventory.");
                return false;
            }
            else
            {
                mainInventory.AddItem(newItem.item);
                return false;
            }
        }
        else
        {

            if (TryAddItemToFreeSlot(newItem))
            {
                return true;
            }
            else
            {
                mainInventory.AddItem(newItem.item);
                return false;
            }
        }
    }

    public bool RemoveItem(InventoryItem itemToRemove)
    {
        if (TryRemoveItemFromInventory(itemToRemove))
        {
            
            return true;  
        }
        return false;
    }

    private bool CanAddToStack(InventoryItem item, int amountToAdd)
    {
        return item.stackSize >= item.amount + amountToAdd;
    }

   
    private InventoryItem FindItemInInventory(InventoryItem item)
    {
       
            foreach (var inventoryItem in items)
            {
                if (inventoryItem != null && inventoryItem.item == item.item)
                {
                    return inventoryItem;
                }
            }
        return null;  
    }

    private bool TryAddItemToFreeSlot(InventoryItem newItem)
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i] != null && items[i].item == null) 
            {
                items[i] = newItem;
                return true;
            }
        }
        return false; 
    }


    private bool TryRemoveItemFromInventory(InventoryItem newItem)
    {
        if (newItem != null)
        {
            for (int i = 0; i < items.Length; i++)
            {
                if (items[i] != null && items[i].item == newItem.item)
                {
                    items[i] = null;
                    return true;
                }
            }
        }
        return false;
    }
}
