//using UnityEngine;
//using System.Collections.Generic;
//using System;
//public class PoolObjectFinder<T> where T : Component
//{
//    private List<Component> pooledObjects = new List<Component>();

//    public PoolObjectFinder(T objectToPool, int amount, Action<T> callBack = null)
//    {
//        CreatePoolObjects(objectToPool, amount, callBack);
//    }

//    public void CreatePoolObjects(T objectToPool, int amount, Action<T> callBack = null)
//    {
//        for (int i = 0; i < amount; i++)
//        {
//            T poolObject = UnityEngine.Object.Instantiate(objectToPool);
//            callBack?.Invoke(poolObject);
//            poolObject.gameObject.SetActive(false);
//            pooledObjects.Add(poolObject);
//        }
//    }

//    public PoolObjectFinder<T> Where(Predicate<T> predicate)
//    {
//        candidates.RemoveAll(x => !predicate(x));
//        return this;
//    }

   

//    public List<T> All()
//    {
//        return candidates;
//    }


//    public PoolObjectFinder<T> ByID(string id)
//    {
//        return Where(x =>
//        {
//            if (x.TryGetComponent<Identifiable>(out var identifiable))
//                return identifiable.ID == id;
//            return false;
//        });
//    }
//}
