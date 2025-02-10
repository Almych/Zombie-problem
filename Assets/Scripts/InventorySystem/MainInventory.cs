using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainInventory : ScriptableObject
{
    private List<Item> items = new List<Item>();

    public void AddItem(Item newItem)
    {
        bool inInventory = false;
        for (int i = 0; i < items.Count; i++)
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
            items.Add(newItem);
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


}
