using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ItemSlotConfig: MonoBehaviour
{
    public Image itemImage;
    public TMP_Text itemAmount;
    public Button useItemEvent;

    //public ItemSlotConfig CreateItemSlot(Sprite item, int amount, Vector3 slotPosition, Transform inventory, UnityAction itemUse)
    //{
    //    ItemSlotConfig itemSlot = new ItemSlotConfig(item, amount, itemUse);
    //    useItemEvent.onClick.AddListener(itemUse);
    //    return itemSlot;
    //}
}
