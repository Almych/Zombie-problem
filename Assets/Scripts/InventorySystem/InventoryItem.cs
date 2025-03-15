using System;

[Serializable]
public class InventoryItem
{
    public Item item;
    public int amount { get; private set; } = 1;
    public int stackSize { get; private set; } = 99;
    public InventorySlot inventorySlot { get; private set; }

    public InventoryItem(Item item)
    {
        this.item = item;
        amount = 1;
        stackSize = 99;
    }

    public void SetSlot(InventorySlot inventorySlot)
    {
        this.inventorySlot = inventorySlot;
    }
    public void AddAmount()
    {
        amount ++;
        inventorySlot.UpdateSlot();
    }
    public void RemoveAmount()
    {
        amount --;
        inventorySlot.UpdateSlot();
        if (amount <= 0)
        {
            inventorySlot?.RemoveSlot();
        }
    }
}
