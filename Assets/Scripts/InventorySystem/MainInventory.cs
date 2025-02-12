using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New MainInventory", menuName = "Inventory/MainInventory")]
public class MainInventory : ScriptableObject
{
    private InventoryItem[] items = new InventoryItem[30];

    public void AddItem(Item newItem)
    {
        bool inInventory = false;
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i].item == newItem && CheckItemSize(items[i], 1))
            {
                items[i].AddAmount(1);
                inInventory = true;
                break;
            }
        }

        if (!inInventory)
        {
            InventoryItem newInventoryItem = new InventoryItem(newItem);
            InventoryItem freePlace = FindFreePlace();
            if (freePlace != null)
                freePlace = newInventoryItem;
        }
    }

    public void RemoveItem(Item removeItem)
    {

    }

    private bool CheckItemSize(InventoryItem item, int fillAmount)
    {
        if (item.stackSize >= item.amount + fillAmount)
            return true;
        else
            return false;
    }

    private InventoryItem FindFreePlace()
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
