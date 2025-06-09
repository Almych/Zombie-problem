using System.Collections.Generic;

[System.Serializable]
public class PlayerData
{
    public string username;
    public int coins;
    public int level;
    public Dictionary<int, LevelProgress> levelProgress;
    public Dictionary<string, WeaponData> weaponsData;
    public Dictionary<string, ItemData> itemsData;
    public string[] items;
    public string[] weapons;
    public string[] lastWeapons;
    public string[] lastItems;

    public PlayerData(MainInventory inventory)
    {
       
    }

    public void SetAllItems(MainInventory inventory)
    {
        items = new string[inventory.items.Count];
        for (int i = 0; i < inventory.items.Count; i++)
        {
            var id = inventory.items[i].item.GetInstanceID().ToString();
            items[i] = id;
            itemsData[id] = new ItemData(inventory.items[i].amount);
        }
    }
    public void SetAllWeapons(MainInventory inventory)
    {
        weapons = new string[inventory.ownedWeapons.Count];
        for (int i = 0; i < inventory.ownedWeapons.Count; i++)
        {
            var id = inventory.ownedWeapons[i].GetInstanceID().ToString();
            weapons[i] = id;
            if (inventory.ownedWeapons[i] is RangeWeaponConfig rangeWeapon)
                weaponsData[id] = new RangeWeaponData(rangeWeapon.damage.ToString(), rangeWeapon.totalAmount, rangeWeapon.isBaseWeapon);
            else
                weaponsData[id] = new MeleeWeaponData(inventory.ownedWeapons[i].damage.ToString());
        }
    }
    public void SetRecentItems(PlayInventory inventory)
    {
        lastItems = new string[inventory.items.Count];
        for (int i = 0; i < inventory.items.Count; i++)
        {
            var id = inventory.items[i].item.GetInstanceID().ToString();
            lastItems[i] = id;
        }
    }
}


[System.Serializable]
public class LevelProgress
{
    public bool isCompleted;
    public int starsEarned;
    public float timeTaken;
    public float damageTaken;
}

[System.Serializable]
public abstract class WeaponData
{
    public string damage { get; private set; }

    protected WeaponData(string damage)
    {
        this.damage = damage;
    }
}

[System.Serializable]
public class RangeWeaponData : WeaponData
{
    public int totalAmount;
    public bool isBaseWeapon;

    public RangeWeaponData(string damage, int totalAmount, bool isBaseWeapon) : base(damage)
    {
        this.totalAmount = totalAmount;
        this.isBaseWeapon = isBaseWeapon;
    }
}
[System.Serializable]
public class ItemData
{
    public int amount { get; private set; }

    public ItemData(int amount)
    {
        this.amount = amount;
    }
}

[System.Serializable]
public class MeleeWeaponData : WeaponData
{
    public MeleeWeaponData(string damage) : base(damage)
    {
    }
}