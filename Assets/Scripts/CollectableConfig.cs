using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New CollectableConfig", menuName = "Collectables")]
public class CollectableConfig : ScriptableObject
{
    public List<ItemsToSpawn> collectables;
    void OnEnable()
    {
        
    }
}


[Serializable]
public class ItemsToSpawn
{
    public readonly GameObject collectItem;
    public readonly int amount;
    private int currAmount => amount;
    public void DeacreaseAmount(Action onEmpty)
    {
        currAmount--;
        if (amount <= 0 )
            onEmpty?.Invoke();
    }
}