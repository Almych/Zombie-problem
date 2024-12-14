using System.Collections.Generic;
using System;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    public static EnemyPool Instance;
    [SerializeField] private int poolSize = 5;
    [SerializeField] private SpawnerOfZombies spawner;

    private List<ZombieData> zombiesPrefabs;
    private Dictionary<Entity, List<Entity>> pools;

    private void Awake()
    {
      if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        zombiesPrefabs = spawner.zombie;
        pools = new Dictionary<Entity, List<Entity>>();

        foreach (var zombiePrefab in zombiesPrefabs)
        {
            List<Entity> pool = new List<Entity>();
            for (int i = 0; i < poolSize; i++)
            {
                Entity zombie = Instantiate(zombiePrefab.zombieType);
                zombie.gameObject.SetActive(false);
                pool.Add(zombie);
            }
            pools[zombiePrefab.zombieType] = pool;
        }
    }

    public Entity GetZombie(Entity typeZombie)
    {
        if (pools.TryGetValue(typeZombie, out List<Entity> pool))
        {
            foreach (var zombie in pool)
            {
                if (!zombie.gameObject.activeInHierarchy)
                {
                    zombie.gameObject.SetActive(true);
                    return zombie;
                }
            }
        }
        return null;
    }

}