using System.Collections.Generic;
using System;
using UnityEngine;

public class ZombiePoolObject : MonoBehaviour
{
    public List<ZombieData> zombiesPrefabs;
    [SerializeField] private int poolSize = 5;

    private Dictionary<AverageZombie, List<AverageZombie>> pools;

    private void Awake()
    {
        pools = new Dictionary<AverageZombie, List<AverageZombie>>();

        foreach (var zombiePrefab in zombiesPrefabs)
        {
            List<AverageZombie> pool = new List<AverageZombie>();
            for (int i = 0; i < poolSize; i++)
            {
                AverageZombie zombie = Instantiate(zombiePrefab.zombieType);
                zombie.gameObject.SetActive(false);
                pool.Add(zombie);
            }
            pools[zombiePrefab.zombieType] = pool;
        }
    }

    public AverageZombie GetZombie(AverageZombie typeZombie)
    {
        if (pools.TryGetValue(typeZombie, out List<AverageZombie> pool))
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