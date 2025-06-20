using System;
using UnityEngine;

[Serializable]
public class InventoryItem
{
    public Item item;

    [SerializeField, Range(1, 99)] private int _amount = 1;
    [SerializeField, Range(99, 99)] private int _stackSize = 99;

    public int amount => _amount;
    public int stackSize => _stackSize;

    
    public void Initialize(int amount = 1, int stackSize = 99)
    {
        item?.Initialize();
        if (_amount <= 0)
        {
            _stackSize = stackSize;
            _amount = Mathf.Max(1, amount);
        }
    } 

    public void AddAmount(int amountToAdd = 1)
    {
        _amount += amountToAdd;
    }

    public void RemoveAmount(int amountToRemove = 1)
    {
        _amount = Mathf.Max(_amount - amountToRemove, 0);
    }

    public bool CanAdd(int amountToAdd)
    {
        return _amount + amountToAdd <= _stackSize;
    }
}
