using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="New Inventory", menuName ="Inventory")]
public class PlayInventory : ScriptableObject
{
    public Item[] items = new Item[5]; 
    public Weapon[] weaponSlots = new Weapon[2]; 
    public void AddSlot(Item newItem)
    {
       bool inInventory = false;
        for (int i = 0; i < items.Length; i++)
        {
            if (newItem == items[i] && CheckItemSize(items[i], newItem.amount))
            {
                items[i].amount += newItem.amount;
                inInventory = true; 
                break;
            }
        }

        if (!inInventory)
        {
            
        }
    }

    private bool CheckItemSize(Item item, int fillAmount)
    {
        if (item.stackSize >= item.amount + fillAmount)
            return true;
        else
            return false;
    }
}

