using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InventoryData : MonoBehaviour
{
    [SerializeField] private Inventory inventory;

    private void Awake()
    {
        Initiate();
    }


    private void Initiate()
    {
        for(int i= 0; i < inventory.slots.Count; i++)
        {
            ItemSlot itemSlot = new ItemSlot(inventory.slots[i].item);
            InventoryDraw.Instance.AddItem(itemSlot);
        }

        for (int i = 0; i < inventory.weaponSlots.Length; i++)
        {
            if (inventory.weaponSlots[i] is MelliWeapon melli)
            {
                MelliWeaponSlot melliWeaponSlot = new MelliWeaponSlot(melli);

                InventoryDraw.Instance.AddWeapon(melliWeaponSlot);
            }
            else if (inventory.weaponSlots[i] is ColdWeapon cold)
            {
                ColdWeaponSlot coldWeaponSlot = new ColdWeaponSlot(cold);
                InventoryDraw.Instance.AddWeapon(coldWeaponSlot);
            }
        }

       
    }
}
