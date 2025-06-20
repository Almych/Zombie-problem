using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private PlayInventory inventory;
    public static InventoryManager Instance;
    public InventorySlot inventorySlot;
    public GameObject coinContainer;
    public TMP_Text coinText;
    private Dictionary<InventoryItem, InventorySlot> slots = new Dictionary<InventoryItem, InventorySlot>();
    private RectTransform rectTransform;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        rectTransform = GetComponent<RectTransform>();
        ObjectPoolManager.CreateObjectPool(inventorySlot, 6);
        InitiateItems();
    }
     
    public void CollectCoins(int amount)
    {
        inventory.AddCoins(amount);
        coinText.text = inventory.ShowCoinAmount().ToString();
        StartCoroutine(ShowCoinContainer());
    }

    private IEnumerator ShowCoinContainer()
    {
        coinContainer.SetActive(true);
        yield return new WaitForSeconds(5);
        coinText.text = string.Empty;
        coinContainer.SetActive(false);
    }
   
    private void InitiateItems()
    {
        for (int i = 0; i < inventory.items.Count; i++)
        {
            if (inventory.items[i].item != null)
            {
                inventory.items[i].Initialize();
            }
        }
    }

    public void CreateInventory()
    {
        for (int i = 0; i < inventory.items.Count; i++)
        {
            if (inventory.items[i].item != null && inventory.items[i] != null)
            CreateSlot(inventory.items[i]);
        }
    }

    public void RemoveFromInventory(InventoryItem removeItem)
    {
        if (inventory.RemoveItem(removeItem))
        {
            if (slots.TryGetValue(removeItem, out InventorySlot removeSlot))
            {
                slots.Remove(removeItem);
                Destroy(removeSlot.gameObject);
            }
        }
    }


    public void AddToInventory(InventoryItem newItem)
    {
        newItem.Initialize();
        InventoryItem existing = inventory.items.Find(i => i.item == newItem.item);
        if (existing != null)
        {
            existing.AddAmount();
            UpdateSlot(existing);
        }
        else
        {
            if (inventory.AddItem(newItem))
            {
                CreateSlot(newItem);
            }
        }
    }



    public void UpdateSlot(InventoryItem inventoryItem)
    {
        if (slots.TryGetValue(inventoryItem, out InventorySlot slot))
        {
            slot.UpdateSlot();
        }
    }

    public void CreateSlot(InventoryItem inventoryItem)
    {
        InventorySlot slot = ObjectPoolManager.FindObject<InventorySlot>();   
        if (slot != null)
        {
            slot.gameObject.SetActive(true);
            slot.transform.SetParent(transform);
            slot.SetInventorySlot(inventoryItem);
            slots[inventoryItem] = slot;
        }
        LayoutRebuilder.ForceRebuildLayoutImmediate(rectTransform);
    }
}
