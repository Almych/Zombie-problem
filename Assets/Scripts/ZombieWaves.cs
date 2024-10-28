using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZombieWaves : MonoBehaviour
{
    public delegate IEnumerator CallZombie(int amount);
    public static CallZombie ZombieWaveChanged;
    public delegate int MaxAmount();
    public static MaxAmount GetMaxAmount;
    [SerializeField] private Slider waveBar;
    private float maxValue;
    private float perSecond = 2f;
    private float looseTime = -0.1f;
    private int amountMax;
    private void Start()
    {
        maxValue = waveBar.maxValue;
        ZombieLeft(maxValue);
        StartCoroutine(CallZombieWave());
    }
    private IEnumerator CallZombieWave()
    {
        Debug.Log("call");
        while (waveBar.value > 0)
        {
            if (waveBar.value <= 0.5f)
            {
                amountMax = GetMaxAmount();
                ZombieWaveChanged?.Invoke(amountMax);
            }else
            {
                Debug.Log("Checked");
                int random = UnityEngine.Random.Range(1, 2);
                ZombieWaveChanged?.Invoke(random);
            }
            Debug.Log("Called");
            yield return new WaitForSeconds(perSecond);
            ZombieLeft(looseTime);
            Debug.Log(waveBar.value);
        }
    }

    private void ZombieLeft( float value)
    {
            waveBar.value += value/ maxValue;
    }
}
