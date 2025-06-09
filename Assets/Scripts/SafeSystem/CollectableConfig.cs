using System;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Collectable Config", menuName = "Config/Collectables")]
public class CollectableConfig : ScriptableObject
{
    public List<CoinCollectableData> coinCollectables;
    public List<ItemCollectableData> itemCollectables;
    public List<WeaponCollectableData> weaponCollectables;

    public void Init()
    {
        foreach (var coin in coinCollectables)
            coin.InitiateConfigData();

        foreach (var item in itemCollectables)
            item.InitiateConfigData();

        foreach (var weapon in weaponCollectables)
            weapon.InitiateConfigData();
    }
}

[Serializable]
public abstract class CollectableData
{
    public int amount;
    [NonSerialized] public int currentAmount;

    public virtual void InitiateConfigData()
    {
        currentAmount = amount;
    }

    public  void DecreaseAmount()
    {
        currentAmount = Mathf.Max(0, currentAmount - 1);
    }
}


[Serializable]
public class CoinCollectableData : CollectableData
{
    public int coinAmount;

}

[Serializable]
public class ItemCollectableData : CollectableData
{
    public InventoryItem item;

    public override void InitiateConfigData()
    {
        base.InitiateConfigData();
        item.item.Initialize();
    }
}

[Serializable]
public class WeaponCollectableData : CollectableData
{
    public WeaponConfig weapon;
    
}
