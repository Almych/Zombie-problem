using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New PlayInventory", menuName = "Inventory/PlayInventory")]
public class PlayInventory : ScriptableObject
{
    [Header("Max amount of items is 5")]
    public List<InventoryItem> items = new();
    [Header("Max amount of weapons is 2")]
    public List<WeaponConfig> weaponSlots = new();
    public MainInventory mainInventory;

    private const int maxItemSlots = 5;
    private const int maxWeaponSlots = 2;

    private void OnValidate()
    {
        if (items.Count > maxItemSlots) { 
            items.RemoveRange(maxItemSlots, items.Count - maxItemSlots);
        }

        if (weaponSlots.Count > maxWeaponSlots)
        {
            weaponSlots.RemoveRange(maxWeaponSlots, weaponSlots.Count - maxWeaponSlots);
        }
    }

    



    /// <summary>
    /// Adds an item to the play inventory or redirects it to main inventory if full or not stackable.
    /// </summary>
    public bool AddItem(InventoryItem newItem)
    {
        if (newItem == null) return false;

        InventoryItem existingItem = FindItemInInventory(newItem);

        if (existingItem != null)
        {
            if (CanAddToStack(existingItem, newItem.amount))
            {
                existingItem.AddAmount(newItem.amount);
                return true;
            }

            mainInventory?.AddItem(newItem);
            return false;
        }

        if (items.Count < maxItemSlots)
        {
            items.Add(newItem);
            return true;
        }

        mainInventory?.AddItem(newItem);
        return false;
    }


    /// <summary>
    /// Adds a weapon to the play inventory or main inventory if not enough space.
    /// </summary>
    public void AddWeapon(WeaponConfig weaponConfig, Action<WeaponConfig> addToPlaySlot)
    {
        if (weaponConfig == null || addToPlaySlot == null) return;

        foreach (var weapon in weaponSlots)
        {
            if (weapon != null && weapon.weaponSprite == weaponConfig.weaponSprite)
            {
                if (weapon is RangeWeaponConfig existing && weaponConfig is RangeWeaponConfig incoming)
                {
                    existing.totalAmount += incoming.totalAmount;
                }
                return;
            }
        }

        if (weaponSlots.Count >= 2)
            return;

        // Check if already owned in main inventory
        var ownedInMain = mainInventory?.ownedWeapons.Find(w => w.weaponSprite == weaponConfig.weaponSprite);
        if (ownedInMain != null)
        {
            if (ownedInMain is RangeWeaponConfig mainRange && weaponConfig is RangeWeaponConfig incomingRange)
            {
                mainRange.totalAmount += incomingRange.totalAmount;
            }
            return;
        }

        addToPlaySlot(weaponConfig);
    }

    public bool RemoveItem(InventoryItem itemToRemove)
    {
        return items.Remove(itemToRemove);
    }

    private bool CanAddToStack(InventoryItem item, int amountToAdd)
    {
        return item.amount + amountToAdd <= item.stackSize;
    }

    private InventoryItem FindItemInInventory(InventoryItem item)
    {
        return items.Find(i => i != null && i.item == item.item);
    }
}
