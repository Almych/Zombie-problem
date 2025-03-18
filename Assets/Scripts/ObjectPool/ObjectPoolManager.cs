using System;
using System.Collections.Generic;
using UnityEngine;

public static class ObjectPoolManager
{
    private static Dictionary<Type, FadeObjectPool> existingPools = new Dictionary<Type, FadeObjectPool>();


    public static void CreateObjectPool<T>(T objectToPool, int amount, Action<T> afterSpawn = null) where T : MonoBehaviour
    {

        if (existingPools.ContainsKey(objectToPool.GetType()))
        {
            return;
        }

        FadeObjectPool fadeObjectPool = new FadeObjectPool();
        fadeObjectPool.Init(objectToPool, amount, afterSpawn);
        existingPools[objectToPool.GetType()] = fadeObjectPool;
    }


    public static T GetObjectFromPool<T>(T typeOfObject) where T : MonoBehaviour
    {
        if (existingPools.ContainsKey(typeOfObject.GetType()))
        {
            return existingPools[typeOfObject.GetType()].GetPooledObject().GetComponent<T>();
        }
        
        return null;
    }

    public static T FindObject<T>() where T : MonoBehaviour
    {
        if (existingPools.ContainsKey(typeof(T)))
        {
            existingPools[typeof(T)].GetPooledObject().GetComponent<T>();
        }
        return null;
    }
}