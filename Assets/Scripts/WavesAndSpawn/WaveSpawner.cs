using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : IEnemySpawner
{
    private Transform spawnPoint;
    private IHandlePosition positionHandler;

    public void InitiateWave(Transform spawnPoint, IHandlePosition positionHandler)
    {
        this.spawnPoint = spawnPoint;
        this.positionHandler = positionHandler;
    }

    public void SpawnEnemy(List<EnemyData> enemies)
    {
        if (enemies.Count == 0) return;

        int index = Random.Range(0, enemies.Count);
        EnemyData selectedEnemy = enemies[index];

        Enemy enemyInstance = ObjectPoolManager.GetObjectFromPool(selectedEnemy.enemyType);
        if (enemyInstance == null) return;

        enemyInstance.gameObject.SetActive(true);
        enemyInstance.Initiate();
        enemyInstance.transform.position = positionHandler.SetPosition(spawnPoint.position);

        selectedEnemy.RemoveAmount();
        if (selectedEnemy.currAmount <= 0)
            enemies.RemoveAt(index);
    }

    public int GetTotalEnemyCount(List<EnemyData> enemies)
    {
        int total = 0;
        foreach (var e in enemies)
            total += e.currAmount;
        return total;
    }
}
