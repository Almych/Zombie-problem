using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InventoryData : MonoBehaviour
{
    public int spacesBetweenX;
    public int startXPositionItems;
    public int startXPositionWeapons;
    public int spacesBetweenY;
    public int collumnsSpaces;
    [SerializeField] private Inventory inventory;
    [SerializeField] private SlotManager slotManager;
    private int createdSlotSPACE = 0;
    private void Start()
    {
        Initiate();
    }


    private void Initiate()
    { 
        for(int i= 0; i < inventory.slots.Count; i++)
        {
            if (inventory.slots[i].item.amount > 0)
            {
                ItemSlotConfig itemSlot = slotManager.CreateItemSlot(inventory.slots[i].item, GetPosition(startXPositionItems, createdSlotSPACE), transform, inventory.slots[i].item.UseItem);
                InventoryDraw.Instance.AddItem(itemSlot);
                createdSlotSPACE++;
            }
        }

        for (int i = 0; i < inventory.weaponSlots.Length; i++)
        {
            WeaponSlotConfig weaponSlot = slotManager.CreateWeaponSlot(inventory.weaponSlots[i], GetPosition(startXPositionWeapons, i), transform);
            InventoryDraw.Instance.AddWeapon(weaponSlot);
        }


    }

    private Vector3 GetPosition(int startXPosition, int i)
    {
        return new Vector3(startXPosition + spacesBetweenX * (i % collumnsSpaces), 0f, 0f);
    }
}
