using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolObjects : MonoBehaviour
{
    public List<MonoBehaviour> objectsToPool = new List<MonoBehaviour>();
    public int poolSize;
    private void Start()
    {
        StartPool();
    }

    public void StartPool()
    {
        for (int i = 0; i < objectsToPool.Count; i++)
        {
            ObjectPoolManager.CreateObjectPool(objectsToPool[i], poolSize);
        }
    }
}
