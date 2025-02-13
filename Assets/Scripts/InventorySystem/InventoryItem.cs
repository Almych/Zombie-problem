using System;
using UnityEngine;

[Serializable]
public class InventoryItem
{
    public Item item;
    [HideInInspector] public int amount { get; private set; } = 1;
    [HideInInspector]public int stackSize { get; private set; } = 99;
    [HideInInspector]public string stackID { get; private set; }
    [HideInInspector] public InventorySlot inventorySlot { get; private set; }

    public InventoryItem(Item item)
    {
        this.item = item;
        amount = 1;
        stackSize = 99;
        stackID = GenerateUniqueStackID(); 
    }

    private string GenerateUniqueStackID()
    {
        return Guid.NewGuid().ToString();
    }

    public void SetSlot(InventorySlot inventorySlot)
    {
        this.inventorySlot = inventorySlot;
    }
    public void AddAmount()
    {
        amount ++;
        inventorySlot.UpdateSlot();
    }
    public void RemoveAmount()
    {
        amount --;
        inventorySlot.UpdateSlot();
        if (amount <= 0)
        {
            inventorySlot?.RemoveSlot();
        }
    }
}
