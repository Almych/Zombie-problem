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
    public ItemObject itemObject;


    private void OnEnable()
    {
        itemObject.OnItemUse += InventoryDraw.Instance.ShowItemAmount;
    }
    private void OnDisable()
    {
        itemObject.OnItemUse -= InventoryDraw.Instance.ShowItemAmount;
    }
}
