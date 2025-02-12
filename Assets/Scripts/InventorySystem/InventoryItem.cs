using System;
using UnityEngine;

[Serializable]
public class InventoryItem
{
    public Item item;
    [HideInInspector]public int amount { get; private set; }
    [HideInInspector]public int stackSize { get; private set; } = 99;
    [HideInInspector]public string stackID { get; private set; }

    public InventoryItem(Item item)
    {
        this.item = item;
        amount = 1;
        stackID = GenerateUniqueStackID(); 
    }

    private string GenerateUniqueStackID()
    {
        return Guid.NewGuid().ToString();
    }

    public void AddAmount(int additionalAmount)
    {
        amount += additionalAmount;
    }

    public int GetAmount()
    {
        return amount;
    }

    public void RemoveAmount(int removeAmount)
    {
        amount -= removeAmount;
        if (amount < 0)
        {
            amount = 0;
        }
    }
}
