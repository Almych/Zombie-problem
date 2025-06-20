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

    
    public int ShowCoinAmount()
    {
        return mainInventory.coins;
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

    public void AddCoins(int amount)
    {
        mainInventory.AddCoins(amount);
    }

    /// <summary>
    /// Adds a weapon to the play inventory or main inventory if not enough space.
    /// </summary>
    public void AddWeapon(WeaponConfig weaponConfig, Action<WeaponConfig> addToPlaySlot)
    {
        if (weaponConfig == null || addToPlaySlot == null) return;

        // Check if the player already has the weapon (to add bullets)
        var findWeapon = PlayerController.Instance.FindRangeWeapon(weaponConfig);
        if (findWeapon != null)
        {
            if (findWeapon is RangeWeapon existing && weaponConfig is RangeWeaponConfig incoming)
            {
                existing.AddAmount(incoming.maxBullets);
                WeaponStateUI.Instance.UpdateBulletAmount();
            }
            return;
        }

        if (weaponSlots.Count >= maxWeaponSlots)
            return;

        var ownedInMain = mainInventory?.ownedWeapons.Find(w => w.weaponSprite == weaponConfig.weaponSprite);
        if (ownedInMain != null)
        {
            if (ownedInMain is RangeWeaponConfig mainRange && weaponConfig is RangeWeaponConfig incomingRange)
            {
                mainRange.totalAmount += incomingRange.maxBullets;
            }
            return;
        }
        weaponSlots.Add(weaponConfig);

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
