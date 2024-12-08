using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ItemSlotConfig
{
    public Image itemImage;
    public TMP_Text itemAmount;
    [SerializeField]private Image X;

    public ItemSlotConfig(Sprite itemUi, int countItem)
    {
        itemImage.sprite = itemUi;
        itemAmount.text = countItem.ToString("n0");
    }

    public ItemSlotConfig CreateItemSlot(Sprite item, int amount, Vector3 slotPosition, Transform inventory, UnityAction itemUse)
    {
        ItemSlotConfig itemSlot = new ItemSlotConfig(item, amount);
        return itemSlot;
    }
}
