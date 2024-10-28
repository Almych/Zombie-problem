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

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
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
    public void CountCoin(int counter)
    {
        counter++;
        coinCounterText.text = counter.ToString();
    }
}
