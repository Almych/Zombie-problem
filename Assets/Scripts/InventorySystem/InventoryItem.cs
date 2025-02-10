using System;
using UnityEngine;
[Serializable]
public class InventoryItem
{
    [HideInInspector]public Item item { get; private set; }
    [HideInInspector]public int amount { get; private set; }
    [HideInInspector]public string stackID { get; private set; }

    public InventoryItem(Item item, int amount)
    {
        this.item = item;
        this.amount = amount;
        this.stackID = GenerateUniqueStackID(); 
    }

    private string GenerateUniqueStackID()
    {
        return Guid.NewGuid().ToString();
    }

    public void AddAmount(int additionalAmount)
    {
        this.amount += additionalAmount;
    }

    public void RemoveAmount(int removeAmount)
    {
        this.amount -= removeAmount;
        if (this.amount < 0)
        {
            this.amount = 0;
        }
    }
}
