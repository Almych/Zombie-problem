using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class WaveUi : MonoBehaviour
{
    [SerializeField] private Slider waveBar;
    [SerializeField] private GameObject wavePrefab;


    public void ChangeWaveBarValue(float value)
    {
        waveBar.value = value;
    }

    public void OnWaveCall()
    {
        
    }
    public void InitWaves(int wavesAmount)
    {
        Vector3 scale = wavePrefab.GetComponent<RectTransform>().localScale;
        float maxWave = waveBar.fillRect.GetComponent<RectTransform>().rect.width;

        // Calculate the spacing between each wave
        float waveSpacing = maxWave / wavesAmount;

        // Loop to instantiate and position the waves
        for (int i = 0; i < wavesAmount; i++)
        {
            // Instantiate the wavePrefab and set its parent
            GameObject waveInstance = Instantiate(wavePrefab);
            waveInstance.transform.SetParent(waveBar.fillRect.transform);

            // Calculate the X position of each wave, ensuring they are evenly spaced
            float positionX = waveSpacing * i -100f;  // This ensures waves don't overlap

            // Set the wave's position and scale

            Vector3 wavePosition = new Vector3(positionX, 0, 0);
            RectTransform waveRect = waveInstance.GetComponent<RectTransform>();
            waveRect.localPosition = wavePosition;
            waveRect.localScale = scale;

            // Optionally log the position for debugging
            Debug.Log("Wave " + i + " positioned at X: " + positionX);
        }

        // Optionally reset the slider value after initializing the waves
        waveBar.value = waveBar.maxValue;
    }


}
