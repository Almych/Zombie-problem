using System;
using UnityEngine;

public static class CollectablesSpawn
{
    public static CollectableConfig collectableConfig;

    // Initialize the collectable configuration
    public static void Init(CollectableConfig config)
    {
        collectableConfig = config;
    }

    // Spawn a random collectable at a given position
    public static void SpawnRandomObject(Vector3 spawnPosition)
    {
        GameObject objectToSpawn = GetRandomObject();
        if (objectToSpawn != null)
        {
            Debug.Log("Finding object to spawn");

            // Get object from object pool
            MonoBehaviour pooledObject = ObjectPoolManager.GetObjectFromPool(objectToSpawn.GetComponent<MonoBehaviour>());

            if (pooledObject != null)
            {
                pooledObject.transform.position = spawnPosition;
                pooledObject.gameObject.SetActive(true);
            }
        }
    }

    // Get a random object from the config
    private static GameObject GetRandomObject()
    {
        if (collectableConfig == null || collectableConfig.collectables.Count == 0)
            return null;

        int randomIndex = UnityEngine.Random.Range(0, collectableConfig.collectables.Count);

        collectableConfig.collectables[randomIndex].DeacreaseAmount(() => collectableConfig.collectables.Remove(collectableConfig.collectables[randomIndex]));
        return collectableConfig.collectables[randomIndex].collectItem;
    }
    
}
