using System;
using System.Collections.Generic;
using UnityEngine;



[Serializable]
public class ItemsToSpawn
{
    public Item item;
    public int amount;
}

public class CollectablesSpawn : MonoBehaviour
{
    public static CollectablesSpawn Instance;

    [SerializeField] private List<ItemsToSpawn> items = new List<ItemsToSpawn>();
    [SerializeField] private int amountOfCoins;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    public void SpawnRandomObject(Vector3 spawnPosition)
    {
        GameObject objectToSpawn = GetRandomObject();
        if (objectToSpawn != null)
        {
            objectToSpawn.transform.position = spawnPosition;
        }
    }

    private GameObject GetRandomObject()
    {
        if (amountOfCoins > 0)
        {
            int index = UnityEngine.Random.Range(0, amountOfCoins);
            var coin = ObjectPoolManager.FindObject<CoinTake>();
            if (coin != null)
            {
                amountOfCoins--;
                coin.gameObject.SetActive(true);
            }
            return coin.gameObject;
        }
        else if (items.Count > 0)
        {
            int index = UnityEngine.Random.Range(0, items.Count);
            var item = items[index];
            item.amount--;

            if (item.amount <= 0)
            {
                items.RemoveAt(index);
            }

            ItemSlot itemSlotComponent = ObjectPoolManager.FindObject<ItemSlot>();
            if (itemSlotComponent != null)
            {
                itemSlotComponent.gameObject.SetActive(true);
                InventoryItem inventoryItem = new InventoryItem(item.item);
                itemSlotComponent.Init(inventoryItem);
            }

            return itemSlotComponent.gameObject;
        }
        else
        {
            return null;
        }
    }
}
