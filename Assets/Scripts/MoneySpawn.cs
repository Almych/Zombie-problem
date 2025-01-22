
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class MoneySpawn : MonoBehaviour
{
    [SerializeField] private CoinPool coinPool;
    private int counter;
    private View ui;
   

    private void Start()
    {
        ui = View.Instance;
        counter = -1;
        ui.CountCoin(ref counter);
    }
    //private void OnEnable()
    //{
    //    Entity.OnCoinSpawn += SpawnCoin;
    //}

    //private void OnDisable()
    //{
    //    Entity.OnCoinSpawn -= SpawnCoin;
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<CoinTake>()!= null)
        {
            ui.CountCoin(ref counter);
            collision.GetComponent<CoinTake>().gameObject.SetActive(false);
        }
    }
    public void SpawnCoin(Vector3 pos)
    {
        var amount = UnityEngine.Random.Range(0, 2);
        for (int i = 0; i < amount; i++)
        {
            CoinTake coin = coinPool.GetCoin();
            if (coin != null)
            {
                coin.transform.position = pos;
                coin.gameObject.SetActive(true);
                StartCoroutine(coin.CoinCollect());
            }
        }
    }

    
}
