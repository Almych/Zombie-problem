using System.Collections;
using UnityEngine;

public interface IEnemySpawner
{
    void InitiateWave(Transform spawnPoint, IHandlePosition positionHandler);
    IEnumerator SpawnEnemies(Wave wave);
}
