using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SlotConfig : MonoBehaviour
{
    [SerializeField] private Image itemsUi;
    [SerializeField] private TMP_Text textAmount;
    [SerializeField] private Image xUi;
    [SerializeField] private Button button;

    public GameObject CreateItemSlot(Sprite itemSprite, int itemAmount, Vector3 slotPosition, Transform inventory, UnityAction itemFunction)
    {
        itemsUi.sprite = itemSprite;
        textAmount.text = itemAmount.ToString("n0");
        var slot = Instantiate(gameObject, Vector2.zero, Quaternion.identity, inventory);
        slot.GetComponent<RectTransform>().localPosition = slotPosition;
        button.onClick.AddListener(itemFunction);
        return slot;
    }

    public GameObject CreateWeaponSlot( Weapon weapon, Vector3 slotPosition, Transform inventory)
    {
        itemsUi.sprite = weapon.weaponIcon;
        if (weapon is MelliWeapon melli)
        {
            textAmount.text = melli.totalBullets.ToString("n0");
        }
        var weaponSlot = Instantiate(gameObject, Vector2.zero, Quaternion.identity, inventory);
        weaponSlot.GetComponent<RectTransform>().localPosition = slotPosition;
        return weaponSlot;
    }
}
