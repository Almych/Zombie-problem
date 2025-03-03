using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CoinCounterUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coinCounterText;
    [SerializeField] private CoinsContainer coinsContainer;

    void OnEnable()
    {
        EventBus.Subscribe<OnCollectEvent>(AddCoin, 1);
    }

    void OnDisable()
    {
        EventBus.UnSubscribe<OnCollectEvent>(AddCoin);
    }

    private void UpdateView()
    {
        coinCounterText.text = coinsContainer.GetCoins().ToString();
    }

    private void AddCoin(OnCollectEvent e)
    {
        coinsContainer.AddCoin();
        UpdateView();
    }
}
