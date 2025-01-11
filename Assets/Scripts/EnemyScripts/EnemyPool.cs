using System.Collections.Generic;
using System;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    public static EnemyPool Instance;
    private const int poolSize = 7;
    private static Queue<Entity> pooledEnemies = new Queue<Entity>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    public void InitiateEnemy(Entity enemyType)
    {
        for (int i = 0; i < poolSize; i++)
        {
           var enemy = Instantiate(enemyType.gameObject);
           enemy.gameObject.SetActive(false);
           pooledEnemies.Enqueue(enemy.GetComponent<Entity>());
        }
    }

    public Entity GetEnemy(Entity enemyType)
    {
       
       foreach(var enemy in pooledEnemies)
        {
            if (enemy.GetType() == enemyType.GetType() && !enemy.isActiveAndEnabled)
            {
                return enemy;
            }
        }

        return null;
    }
}