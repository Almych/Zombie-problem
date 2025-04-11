using System;
using System.Collections.Generic;
using UnityEngine;

public static class ObjectPoolManager
{
    private static Dictionary<Component, FadeObjectPool> existingPools = new Dictionary<Component, FadeObjectPool>();
    private static Dictionary<Type, FadeObjectPool>  poolsByTypes = new Dictionary<Type, FadeObjectPool>();
    private static Dictionary<string, FadeObjectPool> poolsByName = new Dictionary<string, FadeObjectPool>();
    public static void CreateObjectPool<T>(T objectToPool, int amount, Action<T> afterSpawn = null) where T : Component
    {

        if (existingPools.ContainsKey(objectToPool))
        {
            return;
        }

        FadeObjectPool fadeObjectPool = new FadeObjectPool();
        fadeObjectPool.Init(objectToPool, amount, afterSpawn);
        existingPools[objectToPool] = fadeObjectPool;
        poolsByTypes[objectToPool.GetType()] = fadeObjectPool;
        poolsByName[objectToPool.name] = fadeObjectPool;
    }


    public static T GetObjectFromPool<T>(T typeOfObject) where T : Component
    {
        if (existingPools.ContainsKey(typeOfObject))
        {
            return existingPools[typeOfObject]?.GetPooledObject()?.GetComponent<T>();
        }
        
        return null;
    }

    public static T FindObject<T>() where T : Component
    {
        if (poolsByTypes.ContainsKey(typeof(T)))
        {
           return  poolsByTypes[typeof(T)]?.GetPooledObject()?.GetComponent<T>();
        }
        return null;
    }

    public static T FindObjectByName<T>(string objectName) where T: Component
    {
        if (poolsByName.ContainsKey(objectName))
        {
            return poolsByName[objectName]?.GetPooledObject()?.GetComponent<T>();
        }
        return null;
    }

    public static void ClearObjectsFromPool()
    {
        poolsByName.Clear();
        poolsByTypes.Clear();
        existingPools.Clear();
    }
}