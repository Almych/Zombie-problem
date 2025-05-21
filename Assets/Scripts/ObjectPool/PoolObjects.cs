using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolObjects : MonoBehaviour
{
    public List<Component> objectsToPool = new List<Component>();
    public GrenadeThrowable grenadeThrowable;
    public int poolSize;

    void Awake()
    {
        StartPool();
    }


    public void StartPool()
    {
        for (int i = 0; i < objectsToPool.Count; i++)
        {
            ObjectPoolManager.CreateObjectPool(objectsToPool[i], poolSize);
        }
        ObjectPoolManager.CreateObjectPool(grenadeThrowable, poolSize);
    }
}
