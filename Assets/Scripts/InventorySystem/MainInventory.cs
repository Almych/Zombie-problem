using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MainInventory", menuName = "Inventory/MainInventory")]
public class MainInventory : ScriptableObject
{
    [Header("Currency")]
    public int coins = 0;

    [Header("All Owned Items")]
    public List<InventoryItem> items = new List<InventoryItem>();

    [Header("All Owned Weapons")]
    public List<WeaponConfig> ownedWeapons = new List<WeaponConfig>();

    // === ITEM MANAGEMENT ===

    public void AddItem(InventoryItem item, int amount = 1)
    {
        var existing = FindItem(item);
        if (existing != null)
        {
            existing.AddAmount(amount);
        }
        else
        {
            items.Add(item);
        }
    }

    public void RemoveItem(InventoryItem item, int amount = 1)
    {
        var existing = FindItem(item);
        if (existing != null)
        {
            existing.RemoveAmount(amount);
            if (existing.amount <= 0)
                items.Remove(existing);
        }
    }

    private InventoryItem FindItem(InventoryItem item)
    {
        return items.Find(i => i == item);
    }

    // === WEAPON MANAGEMENT ===

    public void AddWeapon(WeaponConfig weapon)
    {
        if (!ownedWeapons.Contains(weapon))
        {
            ownedWeapons.Add(weapon);
        }
    }

    public void RemoveWeapon(WeaponConfig weapon)
    {
        ownedWeapons.Remove(weapon);
    }

    // === COIN MANAGEMENT ===

    public void AddCoins(int amount)
    {
        coins += amount;
    }

    public void SpendCoins(int amount)
    {
        coins = Mathf.Max(0, coins - amount);
    }
}
