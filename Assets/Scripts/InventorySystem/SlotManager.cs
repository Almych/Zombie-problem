using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SlotManager : MonoBehaviour
{
    [SerializeField] private static ItemSlotConfig ItemSlot;
    [SerializeField] private static WeaponSlotConfig WeaponSlot;

    public static GameObject CreateItemSlot(Sprite itemSprite, int itemAmount, Vector3 slotPosition, Transform inventory, UnityAction itemFunction)
    {
        ItemSlot.itemImage.sprite = itemSprite;
        ItemSlot.itemAmount.text = itemAmount.ToString("n0");
        ItemSlot.useItemEvent.onClick.AddListener(itemFunction);
        GameObject item = Instantiate(ItemSlot.gameObject, Vector2.zero, Quaternion.identity, inventory);
        item.GetComponent<RectTransform>().localPosition = slotPosition;
        return item;
    }

    public static GameObject CreateWeaponSlot(Weapon weapon, Vector3 slotPosition, Transform inventory)
    {
       WeaponSlot.weaponLabel.sprite = weapon.weaponIcon;
        if (weapon is MelliWeapon melli)
        {
           WeaponSlot.weaponBulletAmount.text = melli.totalBullets.ToString("n0");
        }
        var weaponSlot = Instantiate(WeaponSlot.gameObject, Vector2.zero, Quaternion.identity, inventory);
        weaponSlot.GetComponent<RectTransform>().localPosition = slotPosition;
        return weaponSlot;
    }
}
