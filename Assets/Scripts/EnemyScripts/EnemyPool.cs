using System.Collections.Generic;
using System;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    public static EnemyPool Instance;
    private const int poolSize = 7;
    private static List<Entity> pooledEnemies = new List<Entity>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    public void InitiateEnemy(Entity enemyType)
    {
        for (int i=0; i < poolSize; i++)
        {
           var enemy = Instantiate(enemyType);
           enemy.gameObject.SetActive(false);
            pooledEnemies.Add(enemy);
        }
    }

    public Entity GetEnemy(Entity enemyType)
    {
       foreach(var enemy in pooledEnemies)
        {
            if (enemy == enemyType && !enemy.isActiveAndEnabled)
            {
                return enemy;
            }
        }

        return null;
    }
}