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
    private void Start()
    {
        Initiate();
    }


    private void Initiate()
    {
        for(int i= 0; i < inventory.slots.Count; i++)
        {
            var itemSlot = slotManager.CreateItemSlot(inventory.slots[i].item, GetPosition(startXPositionItems, i), transform, inventory.slots[i].item.UseItem);
            InventoryDraw.Instance.AddItem(itemSlot);
        }

        for (int i = 0; i < inventory.weaponSlots.Length; i++)
        {
            var weaponSlot = slotManager.CreateWeaponSlot(inventory.weaponSlots[i], GetPosition(startXPositionWeapons, i), transform);
            InventoryDraw.Instance.AddWeapon(weaponSlot);
        }


    }

    private Vector3 GetPosition(int startXPosition, int i)
    {
        return new Vector3(startXPosition + spacesBetweenX * (i % collumnsSpaces), 0f, 0f);
    }
}
