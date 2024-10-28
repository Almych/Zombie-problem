
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class MoneySpawn : MonoBehaviour
{
    [SerializeField] private GameObject coinPrefab;
    private int counter = -1;
    private View ui;
   

    private void Start()
    {
        ui = View.Instance;
        ui.CountCoin(counter);
    }
    private void OnEnable()
    {
        AverageZombie.CoinCall += SpawnCoin;
    }

    private void OnDisable()
    {
        AverageZombie.CoinCall -= SpawnCoin;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<CoinTake>()!= null)
        {
            ui.CountCoin(counter);
            collision.gameObject.SetActive(false);
        }
    }
    public void SpawnCoin(Vector3 pos)
    {
        var amount = UnityEngine.Random.Range(0, 2);
        for (int i = 0; i < amount; i++)
        {
             Instantiate(coinPrefab, pos, Quaternion.identity);
        }
    }

    
}
