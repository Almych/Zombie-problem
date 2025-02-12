using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="New PlayInventory", menuName ="Inventory/PlayInventory")]
public class PlayInventory : ScriptableObject
{
    public InventoryItem[] items = new InventoryItem[5]; 
    public Weapon[] weaponSlots = new Weapon[2];
    public MainInventory mainInventory;
    public void AddSlot(Item newItem)
    {
       bool inInventory = false;
        for (int i = 0; i < items.Length; i++)
        {
            if (newItem == items[i].item && CheckItemSize(items[i], 1))
            {
                items[i].AddAmount(1);
                inInventory = true; 
                break;
            }
        }

        if (!inInventory)
        {
           mainInventory.AddItem(newItem);
        }
    }

    private bool CheckItemSize(InventoryItem item, int fillAmount)
    {
        if (item.stackSize >= item.amount + fillAmount)
            return true;
        else
            return false;
    }
}

