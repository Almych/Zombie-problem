using UnityEngine;
using TMPro;
public class CoinCounterUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coinCounterText;
    [SerializeField] private CoinsContainer coinsContainer;

    void Awake()
    {
        EventBus.Subscribe<OnCollectEvent>(AddCoin);
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
