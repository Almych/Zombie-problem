using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CoinPool : MonoBehaviour
{
    [SerializeField] private CoinTake coinPrefab;
    [SerializeField] private int amountCoin;
    private List<CoinTake> coinTakeList = new List<CoinTake>();
    private void Awake()
    {
        for (int i = 0; i < amountCoin; i++)
        {
            var coin = Instantiate(coinPrefab);
            coin.gameObject.SetActive(false);
            coinTakeList.Add(coin);
        }
    }

    public CoinTake GetCoin()
    {
        for (int i = 0; i < coinTakeList.Count; i++)
        {
            if (!coinTakeList[i].gameObject.activeInHierarchy)
            {
                return coinTakeList[i];
            }
        }
        return null;
    }
}
