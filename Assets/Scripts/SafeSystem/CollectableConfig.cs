using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Collectable Config", menuName = "Config/Collectables")]
public class CollectableConfig : ScriptableObject
{
    public List<Collectable> collectables;

    void OnEnable()
    {
        foreach(Collectable collectable in collectables)
        {
            collectable.InitiateConfigData();
        }
    }
}


[Serializable]
public class Collectable
{
    public int currentAmount { get; private set; }
    public GameObject collectItem;

    [SerializeField] private int amount;

    public void InitiateConfigData()
    {
        currentAmount = amount;
    }
    
    public void DeacreaseAmount()
    {
        currentAmount--;
        if (currentAmount <= 0)
            return;
    }
}