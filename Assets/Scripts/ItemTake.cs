public class ItemTake : Takable
{
    
    private InventoryItem inventoryItem;
    
    public override void OnCollect()
    {
        EventBus.Publish(new OnCollectEvent(inventoryItem));
        base.OnCollect();
    }

    public void SetCollectable(InventoryItem item)
    {
        inventoryItem = item;
        render.sprite = inventoryItem.item.Sprite;
    }
}