using System;

[Serializable]
public class InventoryItem
{
    public Item item;
    public int amount { get; private set; } = 1;
    public int stackSize { get; private set; } = 99;

    public InventoryItem(Item item)
    {
        this.item = item;
        amount = 1;
        stackSize = 99;
    }

    public void AddAmount()
    {
        amount ++;
    }
    public void RemoveAmount()
    {
        amount --;
    }
}
