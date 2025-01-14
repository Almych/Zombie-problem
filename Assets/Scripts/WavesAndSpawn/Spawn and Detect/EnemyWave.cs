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


public class EnemyWave
{
    public EnemyData[] wave;
    public EnemyData[] preWave;
    public float wavePercent;


    public EnemyWave(EnemyData[] wave, EnemyData[] preWave, float percent)
    {
        this.wave = wave;
        this.preWave = preWave;
        wavePercent = percent;
    }

}