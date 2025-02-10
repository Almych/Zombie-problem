using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SlotManager : MonoBehaviour
{
    [SerializeField] private InventorySlot ItemSlot;
    [SerializeField] private WeaponSlotConfig WeaponSlot;

    public InventorySlot CreateItemSlot(Item item, Vector3 slotPosition, Transform inventory, UnityAction itemFunction)
    {
        ItemSlot.itemImage.sprite = item.sprite;
        ItemSlot.itemAmount.text = item.amount.ToString("n0");
        //ItemSlot.item = item;
        var itemSlot = Instantiate(ItemSlot, Vector2.zero, Quaternion.identity, inventory);
        itemSlot.gameObject.GetComponent<RectTransform>().localPosition = slotPosition;
        itemSlot.gameObject.transform.GetChild(0).GetComponent<Button>().onClick.AddListener(itemFunction);
        return itemSlot;
    }

    public WeaponSlotConfig CreateWeaponSlot(Weapon weapon, Vector3 slotPosition, Transform inventory)
    {
       WeaponSlot.weaponLabel.sprite = weapon.weaponIcon;
        if (weapon is MelliWeapon melli)
        {
            WeaponSlot.weapon = melli;
           WeaponSlot.weaponBulletAmount.text = melli.totalBullets.ToString("n0");
        }
        var weaponSlot = Instantiate(WeaponSlot, Vector2.zero, Quaternion.identity, inventory);
        weaponSlot.gameObject.GetComponent<RectTransform>().localPosition = slotPosition;
        return weaponSlot;
    }
}
