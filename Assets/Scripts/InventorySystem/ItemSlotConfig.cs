using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image itemImage => GetComponent<Image>();
    public TMP_Text itemAmount => GetComponent<TMP_Text>();
    
    public InventoryItem inventoryItem { get; private set; }

    public InventorySlot(InventoryItem inventoryItem)
    {
        itemImage.sprite = inventoryItem.item.sprite;
        itemAmount.text = inventoryItem.amount.ToString();
        this.inventoryItem = inventoryItem;
    }
}
