using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private PlayInventory inventory;
    [SerializeField] private InventorySlot slotPrefab;
    [SerializeField] private List<InventoryItem> InventoryItems;
    public void Init()
    {
        for (int i = 0; i < inventory.items.Length; i++)
        {
            //InventoryItem inventoryItem = new InventoryItem(inventory.items[i]);
            //InventoryItems.Add(inventoryItem);
            //InventorySlot slot = Instantiate(slotPrefab.gameObject).GetComponent<InventorySlot>();
            //slot.Initiate(inventoryItem);
        }
    } 
}
