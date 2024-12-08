using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InventoryData : MonoBehaviour
{
    public SlotConfig slotConfig;
    [SerializeField] private Inventory inventory;

    private void Start()
    {
        Initiate();
    }


    private void Initiate()
    {
        for(int i= 0; i < inventory.slots.Count; i++)
        {
           //var item = slotConfig.CreateItemSlot()
           // Debug.Log(itemSlot);
           // InventoryDraw.Instance.AddItem(itemSlot);
        }

        //for (int i = 0; i < inventory.weaponSlots.Length; i++)
        //{
        //    if (inventory.weaponSlots[i] is MelliWeapon melli)
        //    {
        //        MelliWeaponSlot melliWeaponSlot = gameObject.AddComponent<MelliWeaponSlot>();

        //        InventoryDraw.Instance.AddWeapon(melliWeaponSlot);
        //    }
        //    else if (inventory.weaponSlots[i] is ColdWeapon cold)
        //    {
        //        ColdWeaponSlot coldWeaponSlot = new ColdWeaponSlot(cold);
        //        InventoryDraw.Instance.AddWeapon(coldWeaponSlot);
        //    }
        //}

       
    }
}
