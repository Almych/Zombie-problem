using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public interface IEnemySpawner
{
    void InitiateWave(Transform spawnPoint, IHandlePosition positionHandler);
    void SpawnEnemy(List<EnemyData> spawnEnemies);
}
