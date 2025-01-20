using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SlotManager : MonoBehaviour
{
    [SerializeField] private ItemSlotConfig ItemSlot;
    [SerializeField] private WeaponSlotConfig WeaponSlot;

    public ItemSlotConfig CreateItemSlot(ItemObject itemObject, Vector3 slotPosition, Transform inventory, UnityAction itemFunction)
    {
        ItemSlot.itemImage.sprite = itemObject.prefab;
        ItemSlot.itemAmount.text = itemObject.amount.ToString("n0");
        ItemSlot.itemObject = itemObject;
        var item = Instantiate(ItemSlot, Vector2.zero, Quaternion.identity, inventory);
        item.gameObject.GetComponent<RectTransform>().localPosition = slotPosition;
        item.gameObject.transform.GetChild(0).GetComponent<Button>().onClick.AddListener(itemFunction);
        return item;
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
