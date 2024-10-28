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

    private View ui;
    private const float maxValue = 1f;
    private float perSecond = 2f;
    private float looseTime = -0.1f;
    private int amountMax;
    private void Start()
    {
        ui = View.Instance;
        ui.ZombieLeft(maxValue, maxValue);
        StartCoroutine(CallZombieWave());
    }
    private IEnumerator CallZombieWave()
    {
        Debug.Log("call");
        while (ui.GetWaveValue() > 0)
        {
            if (ui.GetWaveValue() <= 0.5f)
            {
                amountMax = GetMaxAmount();
                StartCoroutine(ZombieWaveChanged?.Invoke(amountMax));
            }else
            {
                Debug.Log("Checked");
                int random = UnityEngine.Random.Range(1, 2);
                StartCoroutine(ZombieWaveChanged?.Invoke(random));
            }
            Debug.Log("Called");
            yield return new WaitForSeconds(perSecond);
            ui.ZombieLeft(looseTime, maxValue);
        }
    }

   
}
