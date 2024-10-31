
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class MoneySpawn : MonoBehaviour
{
    [SerializeField] private GameObject coinPrefab;
    private static int counter;
    private View ui;
   

    private void Start()
    {
        ui = View.Instance;
        counter = -1;
        ui.CountCoin(ref counter);
    }
    private void OnEnable()
    {
        Enemy.OnDeathAddition += SpawnCoin;
    }

    private void OnDisable()
    {
        Enemy.OnDeathAddition -= SpawnCoin;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<CoinTake>()!= null)
        {
            Debug.Log("Coin");
            ui.CountCoin(ref counter);
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
