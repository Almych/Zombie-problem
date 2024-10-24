
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class MoneySpawn : MonoBehaviour
{
    public static MoneySpawn Instance;
    [SerializeField] private TextMeshProUGUI coinCounterText;
    [SerializeField] private GameObject coinPrefab;
    private int counter;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        
    }

    private void Start()
    {
        coinCounterText.text = counter.ToString();
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
            CountCoin();
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

    private void CountCoin()
    {
        counter++;
        coinCounterText.text = counter.ToString();
    }
}
