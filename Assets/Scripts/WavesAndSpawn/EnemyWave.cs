using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
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
}