using System.Collections.Generic;
using System;
using UnityEngine;

public class ZombiePoolObject : MonoBehaviour
{
    public List<ZombieData> zombiesPrefabs;
    [SerializeField] private int poolSize = 5;

    private Dictionary<Enemy, List<Enemy>> pools;

    private void Awake()
    {
        pools = new Dictionary<Enemy, List<Enemy>>();

        foreach (var zombiePrefab in zombiesPrefabs)
        {
            List<Enemy> pool = new List<Enemy>();
            for (int i = 0; i < poolSize; i++)
            {
                Enemy zombie = Instantiate(zombiePrefab.zombieType);
                zombie.gameObject.SetActive(false);
                pool.Add(zombie);
            }
            pools[zombiePrefab.zombieType] = pool;
        }
    }

    public Enemy GetZombie(Enemy typeZombie)
    {
        if (pools.TryGetValue(typeZombie, out List<Enemy> pool))
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