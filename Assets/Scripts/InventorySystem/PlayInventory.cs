using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;
[CreateAssetMenu(fileName ="New PlayInventory", menuName ="Inventory/PlayInventory")]
public class PlayInventory : ScriptableObject
{
    public InventoryItem[] items = new InventoryItem[5]; 
    public Weapon[] weaponSlots = new Weapon[2];
    public MainInventory mainInventory;
    public bool AddItem(Item newItem)
    {
        InventoryItem inventoryItem = FindFreeInventoryPlace();
        if (inventoryItem != null)
        {
            inventoryItem = new InventoryItem(newItem);
            return true;
        }
        else
        {
            mainInventory.AddItem(newItem);
            return false;
        }
    }

    public bool RemoveItem(Item removeItem)
    {
        InventoryItem inventoryItem = FindItemInInventory(removeItem);
        if (inventoryItem != null)
        {
            inventoryItem = null;
            return true;
        }
        return false;
    }

    private bool CheckItemSize(InventoryItem item, int fillAmount)
    {
        if (item.stackSize >= item.amount + fillAmount)
            return true;
        else
            return false;
    }

    private InventoryItem FindItemInInventory(Item newItem)
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (newItem == items[i].item && CheckItemSize(items[i], 1))
            {
                return items[i];
            }
        }

        return FindFreeInventoryPlace();
    }

    private InventoryItem FindFreeInventoryPlace()
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i].item == null)
            {
                return items[i];
            }
        }

        return null;
    }
}

