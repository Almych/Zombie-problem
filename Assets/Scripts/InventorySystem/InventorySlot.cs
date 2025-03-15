using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public InventoryItem inventoryItem { get; private set; }

    private Image itemImage;
    private TMP_Text itemAmount;
    private Button useButton;

    void Awake()
    {
        Init();
    }

    public void Init()
    {
        itemImage = transform.GetChild(0).GetComponent<Image>();
        itemAmount = transform.GetChild(0).GetChild(0).GetComponent<TMP_Text>();
        useButton = GetComponent<Button>();
    }

    public void SetInventorySlot(InventoryItem inventoryItem)
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
