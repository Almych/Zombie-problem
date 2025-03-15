using System;
using System.Collections.Generic;
using UnityEngine;


public class FadeObjectPool
{
    private MonoBehaviour objectToPool;
    private int amount;
    private List<GameObject> pooledObjects = new List<GameObject> ();

    public FadeObjectPool(MonoBehaviour objectToPool, int amount)
    {
        this.objectToPool = objectToPool;
        this.amount = amount;
        CreatePoolObjects();
    }

    private void CreatePoolObjects()
    {
        for (int i = 0; i < amount; i++)
        {
            MonoBehaviour poolObject = UnityEngine.Object.Instantiate(objectToPool);
            poolObject.gameObject.SetActive(false);
            pooledObjects.Add(poolObject.gameObject);
        }
    }

    public MonoBehaviour GetPooledObject()
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i].GetComponent<MonoBehaviour>();
            }
        }
        return null;
    }

    
}
