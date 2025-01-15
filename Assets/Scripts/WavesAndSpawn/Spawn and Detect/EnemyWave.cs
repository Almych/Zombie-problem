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
    public EnemyData[] wave;
    public EnemyData[] preWave;
}