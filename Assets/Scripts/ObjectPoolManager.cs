using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class ObjectPoolManager
{
    private static Dictionary<Type, FadeObjectPool> existingPools = new Dictionary<Type, FadeObjectPool>();


    public static void CreateObjectPool<T>(T objectToPool, int amount) where T: MonoBehaviour
    {

        if (existingPools.ContainsKey(objectToPool.GetType()))
        {
            return;
        }

        FadeObjectPool fadeObjectPool = new FadeObjectPool(objectToPool, amount);
        existingPools[objectToPool.GetType()] = fadeObjectPool;
    }


    public static T GetObjectFromPool<T>(T typeOfObject) where T : MonoBehaviour
    {
        if (!existingPools.ContainsKey(typeOfObject.GetType()))
        {
            return null;
        }
        Type[] types = existingPools.Keys.ToArray();
        for(int i =0; i < types.Length; i++)
        {
            if (types[i] == typeOfObject.GetType())
            {
                return existingPools[types[i]].GetPooledObject().GetComponent<T>();
            }
        }
        return null;
    }


}