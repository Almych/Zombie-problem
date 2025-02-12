using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class CoinsToSpawn
{
    public GameObject objectToSpawn;
    public int amount;
}

[Serializable]
public class ItemsToSpawn
{
    public InventoryItem item;
    public int amount;
}

public class CollectablesSpawn : MonoBehaviour
{
    public static CollectablesSpawn Instance;
    [SerializeField] private List<ItemsToSpawn> items = new List<ItemsToSpawn>();
    [SerializeField] private List<CoinsToSpawn> coins = new List<CoinsToSpawn>();
    [SerializeField] private ItemSlot itemSlot;

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
            Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);
        }
    }

    private GameObject GetRandomObject()
    {
        if (coins.Count > 0)
        {
            int index = UnityEngine.Random.Range(0, coins.Count);
            var coin = coins[index];
            coin.amount--;

            if (coin.amount <= 0)
            {
                coins.RemoveAt(index);
            }

            return coin.objectToSpawn;
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

            itemSlot.Init(item.item);
            return itemSlot.gameObject;
        }
        else
        {
            return null;
        }
    }
}
