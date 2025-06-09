using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    private InventoryItem inventoryItem;
    private Button useButton;
    private Image itemImage;
    private TMP_Text itemAmount;

    private void Awake()
    {
        Init();
    }

    public void Init()
    {
        useButton = GetComponent<Button>();
        itemImage = transform.GetChild(0).GetComponent<Image>();
        itemAmount = transform.GetChild(0).GetChild(0).GetComponent<TMP_Text>();
        EventBus.Subscribe<OnAimEvent>(WaitUntilAim);
    }

    private void OnDestroy()
    {
        EventBus.UnSubscribe<OnAimEvent>(WaitUntilAim);
    }

    private void WaitUntilAim(OnAimEvent e)
    {
        useButton.interactable = !e.isAiming;
    }

    public void SetInventorySlot(InventoryItem inventoryItem)
    {
        this.inventoryItem = inventoryItem;
        useButton.onClick.AddListener(inventoryItem.item.Use);
        useButton.onClick.AddListener(RemoveAmount);
        itemImage.sprite = inventoryItem.item.Sprite;
        UpdateSlot();
    }

    public void UpdateSlot()
    {
        Debug.Log($"Inventory item amount is {inventoryItem.amount}");
        if (inventoryItem.amount <= 1)
        {
            itemAmount.text = string.Empty;
        }
        else
        {
            itemAmount.text = inventoryItem.amount.ToString();
        }

    }

    public void AddAmount()
    {
        inventoryItem.AddAmount();
        UpdateSlot();
    }

    public void RemoveAmount()
    {
        inventoryItem.RemoveAmount();
        if(inventoryItem.amount <= 0)
        InventoryManager.Instance.RemoveFromInventory(inventoryItem);
        UpdateSlot();
    }
   
}
