using System.Collections.Generic;
using UnityEngine;

public class ObjectPool<T> : MonoBehaviour where T : MonoBehaviour
{
    private T objectToPool;
    private int amount;
    private Queue<T> pooledObjects;

    // Constructor to initialize the pool
    public ObjectPool(T objectToPool, int amount)
    {
        this.objectToPool = objectToPool;
        this.amount = amount;
        pooledObjects = new Queue<T>(amount);
    }

    // Create the pooled objects
    public void CreatePoolObjects()
    {
        for (int i = 0; i < amount; i++)
        {
            T poolObject = Instantiate(objectToPool);
            poolObject.gameObject.SetActive(false);
            pooledObjects.Enqueue(poolObject);
        }
    }

    // Get an object from the pool
    public T GetPooledObject()
    {
        T pooledObject = pooledObjects.Dequeue();
        pooledObject.gameObject.SetActive(true); // Activate the object when it's taken from the pool
        return pooledObject;
    }

    public void HandleObjectDeactivation(T objectToReturn)
    {
        pooledObjects.Enqueue(objectToReturn);
    }
}
