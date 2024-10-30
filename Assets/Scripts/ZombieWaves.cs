using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;


public class ZombieWaves : MonoBehaviour
{
    [Range(0f, 100f)]public List<float> waves = new List<float>();
    public delegate Task  CallZombie(int amount);
    public static CallZombie ZombieWaveChanged;
    public delegate int MaxAmount();
    public static MaxAmount GetMaxAmount;

    private View ui;
    private const float maxValue = 1f;
    private const float perSecond = 2f;
    private float looseTime = -0.1f;
    private int amountMax;
    private CancellationTokenSource tokenSource = new CancellationTokenSource();
    private async void Start()
    {
        ui = View.Instance;
        ui.ZombieLeft(maxValue, maxValue);
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

            if (ui.GetWaveValue() <= 0.5f)
            {
                amountMax = GetMaxAmount();
                ZombieWaveChanged?.Invoke(amountMax);
            }
            else
            {
                int random = UnityEngine.Random.Range(1, 2);
                ZombieWaveChanged?.Invoke(random);
            }

            await Task.Delay(TimeSpan.FromSeconds(perSecond));
            if (tokenSource.IsCancellationRequested)
            {
                return;
            }else
            {
                ui.ZombieLeft(looseTime, maxValue);
            }
        }
    }

}
