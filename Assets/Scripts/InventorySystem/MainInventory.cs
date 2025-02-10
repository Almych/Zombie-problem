using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainInventory : ScriptableObject
{
    private Item[] items = new Item[30];

    public void AddItem(Item newItem)
    {
        bool inInventory = false;
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i] == newItem && CheckItemSize(items[i], newItem.amount))
            {
                items[i].amount += newItem.amount;
                inInventory = true;
                break;
            }
        }

        if (!inInventory)
        {
           Item freePlace = FindFreePlace();
            if (freePlace != null)
                freePlace = newItem;
        }
    }

    public void RemoveItem(Item removeItem)
    {

    }

    private bool CheckItemSize(Item item, int fillAmount)
    {
        if (item.stackSize >= item.amount + fillAmount)
            return true;
        else
            return false;
    }

    private Item FindFreePlace()
    {
        for (int i =0; i < items.Length; i++)
        {
            if (items[i] == null)
            {
                return items[i];
            }
        }
        return null;
    }

}
