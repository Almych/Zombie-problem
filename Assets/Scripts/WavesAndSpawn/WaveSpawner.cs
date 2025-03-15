using System.Collections;
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

    public IEnumerator SpawnEnemies(Wave wave)
    {
        List<EnemyData> enemiesToSpawn = new List<EnemyData>(wave.enemies);
        while (enemiesToSpawn.Count > 0)
        {
            SpawnEnemy(enemiesToSpawn);
            yield return new WaitForSeconds(wave.spawnInterwal);
        }
    }

    private void SpawnEnemy(List<EnemyData> enemies)
    {
        if (enemies.Count == 0) return;

        int index = Random.Range(0, enemies.Count);
        EnemyData selectedEnemy = enemies[index];

        Entity enemyInstance = ObjectPoolManager.GetObjectFromPool(selectedEnemy.enemyType);
        if (enemyInstance == null) return;

        enemyInstance.gameObject.SetActive(true);
        enemyInstance.Initiate();
        enemyInstance.transform.position = positionHandler.SetPosition(spawnPoint.position);

        selectedEnemy.RemoveAmount();
        if (selectedEnemy.currAmount <= 0) enemies.RemoveAt(index);
    }
}
