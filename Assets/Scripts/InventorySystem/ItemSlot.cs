using UnityEngine;
public class ItemSlot : MonoBehaviour, ICollectable
{
    private SpriteRenderer spriteRenderer;
    private InventoryItem inventoryItem;
    
    public void Init(InventoryItem newInventoryItem)
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        inventoryItem = newInventoryItem;
        spriteRenderer.sprite = newInventoryItem.item.Sprite;
    }

    public void OnCollect()
    {
        if (inventoryItem != null)
        {
            InventoryManager.Instance.AddToInventory(inventoryItem);
            gameObject.SetActive(false);
        }
    }

}
