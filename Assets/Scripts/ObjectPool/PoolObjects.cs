using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolObjects : MonoBehaviour
{
    public List<MonoBehaviour> objectsToPool = new List<MonoBehaviour>();
    public int poolSize;

    void OnEnable()
    {
        EventBus.Subscribe<InitiateEvent>(StartPool, 1);
    }

    void OnDisable()
    {
        EventBus.UnSubscribe<InitiateEvent>(StartPool);
    }

    public void StartPool(InitiateEvent e)
    {
        for (int i = 0; i < objectsToPool.Count; i++)
        {
            ObjectPoolManager.CreateObjectPool(objectsToPool[i], poolSize);
        }
    }
}
