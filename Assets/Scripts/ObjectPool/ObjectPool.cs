using System;
using System.Collections.Generic;
using UnityEngine;


public class FadeObjectPool
{
    private int amount;
    private List<Component> pooledObjects = new List<Component>();

    public void Init<T>(T objectToPool, int amount, Action<T> callBack= null) where T : Component
    {
        CreatePoolObjects(objectToPool, amount, callBack);
    }

    public void CreatePoolObjects<T>(T objectToPool, int amount, Action<T> callBack = null) where T : Component
    {
        for (int i = 0; i < amount; i++)
        {
            T poolObject = UnityEngine.Object.Instantiate(objectToPool);
            callBack?.Invoke(poolObject);
            poolObject.gameObject.SetActive(false);
            pooledObjects.Add(poolObject);
        }
    }

    public Component GetPooledObject()
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].gameObject.activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
        return null;
    }

    
}
