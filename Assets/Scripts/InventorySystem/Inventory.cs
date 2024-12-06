using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="New Inventory", menuName ="Inventory")]
public class Inventory : ScriptableObject
{
    public  List<InventorySlot> slots = new List<InventorySlot>();
    public Weapon[] weaponSlots = new Weapon[2]; 
    public void AddSlot(ItemObject _item, int _amount)
    {
       bool inInventory = false;
        for (int i = 0; i < slots.Count; i++)
        {
            if (slots[i].item == _item)
            {
                slots[i].item.amount += _amount;
                inInventory = true; 
                break;
            }
        }

        if (!inInventory)
        {
            slots.Add(new InventorySlot(_item));
        }
    }

}


[System.Serializable]
public class InventorySlot
{
    public ItemObject item;
    public InventorySlot(ItemObject _item)
    {
        item = _item;
    }

    public void AddItem(int value)
    {
        item.amount += value;
    }

}