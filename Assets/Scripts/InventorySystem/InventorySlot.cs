using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image itemImage => transform.GetChild(0).GetComponent<Image>();
    public TMP_Text itemAmount =>transform.GetChild(0).GetChild(0).GetComponent<TMP_Text>();

    public Button useButton => GetComponent<Button>();
    
    public InventoryItem inventoryItem { get; private set; }

    public void Initiate(InventoryItem inventoryItem)
    {
        inventoryItem.SetSlot(this);
        this.inventoryItem = inventoryItem;
        useButton.onClick.AddListener(inventoryItem.item.Use);
        useButton.onClick.AddListener(inventoryItem.RemoveAmount);
        itemImage.sprite = inventoryItem.item.Sprite;
        UpdateSlot();
    }

    public void UpdateSlot()
    {
        if (inventoryItem.amount >= 1)
        itemAmount.text = inventoryItem.amount.ToString();
    }

    public void RemoveSlot()
    {
        InventoryManager.Instance.RemoveFromInventory(inventoryItem);
    }
   
}
