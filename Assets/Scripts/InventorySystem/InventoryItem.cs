using System;
using UnityEngine;

[Serializable]
public class InventoryItem
{
    public Item item;
    public event Action OnAmountChanged;
    public event Action<InventoryItem> OnEmptyAmount;
    [HideInInspector] public int amount { get; private set; } = 1;
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
        OnAmountChanged?.Invoke();
    }
    public void RemoveAmount(int removeAmount)
    {
        amount -= removeAmount;
        OnAmountChanged?.Invoke();
        if (amount <= 0)
        {
            OnEmptyAmount?.Invoke(this);
        }
    }
}
