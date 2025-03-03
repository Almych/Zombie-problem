using System;
using UnityEngine;

public static class CollectablesSpawn
{
    private static CollectableConfig collectableConfig;

    public static void Init(CollectableConfig config)
    {
        collectableConfig = config;
    }

    public static void SpawnRandomObject(Vector3 spawnPosition)
    {
        GameObject objectToSpawn = GetRandomObject();
        if (objectToSpawn != null)
        {
            MonoBehaviour pooledObject = ObjectPoolManager.GetObjectFromPool(objectToSpawn.GetComponent<MonoBehaviour>());

            if (pooledObject != null)
            {
                pooledObject.transform.position = spawnPosition;
                pooledObject.gameObject.SetActive(true);
            }
        }
    }

    private static GameObject GetRandomObject()
    {
        if (collectableConfig == null || collectableConfig.collectables.Count == 0)
            return null;

        int randomIndex = UnityEngine.Random.Range(0, collectableConfig.collectables.Count);
        if (collectableConfig.collectables[randomIndex].currentAmount <= 0)
        {
            return null;
        }
        else
        {
            collectableConfig.collectables[randomIndex].DeacreaseAmount();
            return collectableConfig.collectables[randomIndex].collectItem;
        }
    }
    
}
