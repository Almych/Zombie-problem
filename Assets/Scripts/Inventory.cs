using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="New Inventory", menuName ="Inventory")]
public class Inventory : ScriptableObject
{
    public  List<InventorySlot> slots = new List<InventorySlot>();
    public void AddSlot(ItemObject _item, int _amount)
    {
       bool inInventory = false;
        for (int i = 0; i < slots.Count; i++)
        {
            if (slots[i].item == _item)
            {
                slots[i].amount += _amount;
                inInventory = true; 
                break;
            }
        }

        if (!inInventory)
        {
            slots.Add(new InventorySlot(_item, _amount));
        }
    }
}


[System.Serializable]
public class InventorySlot
{
    public ItemObject item;
    public int amount;

    public InventorySlot(ItemObject _item, int _amount)
    {
        item = _item;
        amount = _amount; 
    }

    public void AddItem(int value)
    {
        amount += value;
    }
}