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

    private void Start()
    {
        Initiate();
    }


    private void Initiate()
    {
        for(int i= 0; i < inventory.slots.Count; i++)
        {
            SlotManager.CreateItemSlot(inventory.slots[i].item.prefab, inventory.slots[i].item.amount, GetPosition(startXPositionItems, i), transform, inventory.slots[i].item.UseItem);
        }

        for (int i = 0; i < inventory.weaponSlots.Length; i++)
        {
            SlotManager.CreateWeaponSlot(inventory.weaponSlots[i], GetPosition(startXPositionWeapons, i), transform);
        }


    }

    private Vector3 GetPosition(int startXPosition, int i)
    {
        return new Vector3(startXPosition + spacesBetweenX * (i % collumnsSpaces), 0f, 0f);
    }
}
