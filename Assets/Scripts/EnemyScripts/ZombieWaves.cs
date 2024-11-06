using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;


public class ZombieWaves : MonoBehaviour
{
    [Range(0f, 100f)]public float[] waves = new float[4];
    public delegate Task  CallZombie(int amount);
    public static CallZombie ZombieWaveChanged;
    public delegate int MaxAmount();
    public static MaxAmount GetAmount;

    private View ui;
    private const float maxValue = 1f;
    private const float perSecond = 4f;
    private float looseTime = -0.1f;
    private int amountMax;
    private int currAmount = 0;
    private CancellationTokenSource tokenSource = new CancellationTokenSource();
    private async void Start()
    {
        ui = View.Instance;
        ui.ZombieLeft(maxValue, maxValue);
        amountMax = GetAmount();
        await CallZombieWaveAsync();
    }
    
    private void OnDisable()
    {
        tokenSource.Cancel();
    }


    private async Task CallZombieWaveAsync()
    {
        while (ui.GetWaveValue() > 0)
        {
            for (int i = 0; i < waves.Length; i++)
            {
                if (ui.GetWaveValue() == waves[i])
                {
                    ZombieWaveChanged?.Invoke(amountMax / 2);
                }
                else
                {
                    int random = UnityEngine.Random.Range(0, 4);
                    if (random <= 3 && random > 1) currAmount = 1;
                    else if (random == 4) currAmount = 2;
                    else currAmount = 0;

                    if (amountMax >= currAmount)
                    {
                        ZombieWaveChanged?.Invoke(currAmount);
                    }
                }
            }
                await Task.Delay(TimeSpan.FromSeconds(perSecond));
                if (tokenSource.IsCancellationRequested)
                {
                    return;
                }
                else
                {
                    ui.ZombieLeft(looseTime, maxValue);
                }
            
        }
    }


}
