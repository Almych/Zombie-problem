using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class View : MonoBehaviour
{
    public static View Instance;
    [SerializeField] private Slider waveBar;
    [SerializeField] private TextMeshProUGUI coinCounterText;
    [SerializeField] private Slider healthbar;
    private static int coinAmount;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void OnEnable()
    {
        HealthBar.OnHealthChanged +=HealthBarUpdate;
    }

    private void OnDisable()
    {
        HealthBar.OnHealthChanged -=HealthBarUpdate;
    }

    public void ZombieLeft(float value, float maxValue)
    {
        waveBar.value += value / maxValue;
    }

    public void HealthBarUpdate(object sender, float value)
    {
        healthbar.value = value;
    }
    public float GetWaveValue()
    {
        return waveBar.value;
    }
    public void CountCoin()
    {
        coinAmount++;
        coinCounterText.text = coinAmount.ToString();
    }
}
