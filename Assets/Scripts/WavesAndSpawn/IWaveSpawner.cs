using System.Collections;
using UnityEngine;

public interface IWaveSpawner
{
    void InitiateWave(Transform spawnPoint, IHandlePosition positionHandler);
    IEnumerator SpawnEnemies(Wave wave);
}
