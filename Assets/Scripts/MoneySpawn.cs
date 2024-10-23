
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MoneySpawn : MonoBehaviour
{
    [SerializeField] private GameObject coinPrefab;

    private void OnEnable()
    {
        AverageZombie.CoinCall += SpawnCoin;
    }

    private void OnDisable()
    {
        AverageZombie.CoinCall -= SpawnCoin;
    }

    public void SpawnCoin(Vector3 pos)
    {
        var amount = Random.Range(0, 2);
        for (int i = 0; i < amount; i ++)
        {
             Instantiate(coinPrefab, pos, Quaternion.identity);
        }
    }
}
