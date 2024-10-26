using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZombieWaves : MonoBehaviour
{
    [SerializeField] private Slider waveBar;
    private float maxValue;

    private void OnEnable()
    {
        SpawnerOfZombies.OnSpawn += ZombieLeft;
    }

    private void OnDisable()
    {
        SpawnerOfZombies.OnSpawn -= ZombieLeft;
    }

    private void ZombieLeft(object sender, float value)
    {
        if (maxValue == 0)
        {
            maxValue = value;
            waveBar.value = maxValue;
        }
        else
        {
            waveBar.value = value;
        }
    }
}
