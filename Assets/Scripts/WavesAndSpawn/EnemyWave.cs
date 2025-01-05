using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct EnemyData
{
    public Entity enemyType;
    public int amount;
}
[Serializable]
public class EnemyWave 
{
    public List<EnemyData> wave = new List<EnemyData>();
    public List<EnemyData> preWave = new List<EnemyData>();
 
    //public List<Entity> GetEnemyTypes()
    //{
    //    List<Entity> list = new List<Entity>();

    //    foreach(var enemy in wave)
    //    {
    //        foreach (var knownEnemy in list)
    //        {
    //            if (enemy.zombieType != knownEnemy)
    //            {
    //                list.Add(enemy.zombieType);
    //            }
    //        }
    //    }
    //    return list;
    //}
}
