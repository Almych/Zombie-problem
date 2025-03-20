using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New EnemyWaveConfig", menuName = "Config/EnemyWave")]
public class WaveConfig : ScriptableObject, IWaveConfig
{
    public LevelWaves[] waves;
    public int amountOfPoolZombie;
    public int TotalWaves => waves.Length;
    void OnEnable()
    {
        foreach (var wave in waves)
        {
            wave.preWave.RestoreAmount();
            wave.wave.RestoreAmount();
        }
    }
    public Wave GetWave(int index) => waves[index].wave;
    public Wave GetPreWave(int index) => waves[index].preWave;

    public void GetAllEnemyTypesInitiate()
    {
        HashSet<Entity> enemyTypes = new HashSet<Entity>();
        foreach (var wave in waves)
        {
            wave.wave.enemies.ForEach(enemy => enemyTypes.Add(enemy.enemyType));
            wave.preWave.enemies.ForEach(enemy => enemyTypes.Add(enemy.enemyType));
        }
        
        foreach(Entity enemyType in enemyTypes)
        {
            ObjectPoolManager.CreateObjectPool(enemyType, amountOfPoolZombie, enemyType => enemyType.Init());
        }
    }
}


[Serializable]
public class Wave
{
    public List<EnemyData> enemies;
    [Range(1,5)]public float spawnInterwal;

    public void RestoreAmount()
    {
        foreach(EnemyData enemyData in enemies)
        {
            enemyData.InitAmount();
        }
    }
}

[Serializable]
public struct LevelWaves
{
    public Wave wave;
    public Wave preWave;
}
