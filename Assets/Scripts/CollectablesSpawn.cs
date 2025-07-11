using System;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public static class CollectablesSpawn
{
    private static CollectableConfig config;
    private static readonly List<CollectableData> allCollectables = new();

    public static void Init(CollectableConfig collectableConfig)
    {
        config = collectableConfig;
        allCollectables.Clear();

        allCollectables.AddRange(config.coinCollectables);
        allCollectables.AddRange(config.itemCollectables);
        allCollectables.AddRange(config.weaponCollectables);
    }

    public static void SpawnRandomObject(Vector3 spawnPosition)
    {
        var takable = CreateTakableFromData();
        if (takable != null)
        {
            takable.transform.position = spawnPosition;
            takable.gameObject.SetActive(true);
            takable.transform.DOJump(takable.transform.position + Vector3.right * UnityEngine.Random.Range(-1f, 1f), 1.5f, 1, 0.5f);
        }
    }

    private static CollectableData GetRandomObject()
    {
        if (allCollectables.Count == 0) return null;

        var available = allCollectables.FindAll(c => c.currentAmount > 0);
        if (available.Count == 0) return null;

        var selected = available[UnityEngine.Random.Range(0, available.Count)];
        selected.DecreaseAmount();
        return selected;
    }

    private static Takable CreateTakableFromData()
    {
        var data = GetRandomObject();
        if (data is CoinCollectableData coinData)
        {
            var coin = ObjectPoolManager.FindObject<CoinTake>();
            coin?.SetCollectable(coinData.coinAmount);
            return coin;
        }
        else if (data is ItemCollectableData itemData)
        {
            var item = ObjectPoolManager.FindObject<ItemTake>();
            item?.SetCollectable(itemData.item);
            return item;
        }
        else if (data is WeaponCollectableData weaponData)
        {
            var weapon = ObjectPoolManager.FindObject<WeaponTake>();
            weapon?.SetCollectable(weaponData.weapon);
            return weapon;
        }
        else
        return null;
    }
}
