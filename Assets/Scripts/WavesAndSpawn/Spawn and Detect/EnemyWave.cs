using System;
using UnityEngine;

[Serializable]
public class EnemyData
{
    public Enemy enemyType;
    [SerializeField]private int amount;
    public int currAmount { get; private set; }

    public void InitAmount()
    {
        currAmount = amount;
    }

    public void RemoveAmount()
    {
        currAmount--;
    }
}
