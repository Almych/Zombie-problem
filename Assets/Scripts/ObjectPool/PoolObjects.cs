using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PoolObjects : MonoBehaviour
{
    public List<Component> objectsToPool = new List<Component>();
    public int poolSize;
    public List<Takable> takables;
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

        for (int i = 0;i < takables.Count; i++)
        {
            ObjectPoolManager.CreateObjectPool(takables[i], poolSize, t => t.Init());
        }
    }
}
