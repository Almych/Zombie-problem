using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;

public class WaveUi : MonoBehaviour
{
    [SerializeField] private Slider waveBar;
    [SerializeField] private GameObject wavePrefab;

    private const float FILLRECTMAXXPOSITION = 260f;
    private List<GameObject> waves = new List<GameObject>();
    private int waveIndex = 0;
    private float waveStep; 

    void Awake()
    {
        EventBus.Subscribe<WaveProgressChangeEvent>(ChangeWaveBarValue);
        EventBus.Subscribe<OnWaveReached>(OnWaveReached);
    }

    void OnDestroy()
    {
        EventBus.UnSubscribe<WaveProgressChangeEvent>(ChangeWaveBarValue);
        EventBus.UnSubscribe<OnWaveReached>(OnWaveReached);
    }

    public void InitWaves(int waveMaxAmount)
    {
        waveBar.maxValue = 100f;
        waveBar.value = waveBar.maxValue;

        waveStep = FILLRECTMAXXPOSITION / (waveMaxAmount + 1); 
        Vector3 scale = wavePrefab.GetComponent<RectTransform>().localScale;
        var fill = waveBar.fillRect.parent.GetComponent<RectTransform>();

        for (int i = 0; i < waveMaxAmount; i++)
        {
            GameObject wave = Instantiate(wavePrefab, fill);
            var rect = wave.GetComponent<RectTransform>();
            rect.localPosition = new Vector2(SetWavePosition(i + 1, waveMaxAmount), fill.localPosition.y);
            rect.localScale = scale;

            waves.Add(wave);
        }
    }

    public void ChangeWaveBarValue(WaveProgressChangeEvent e)
    {
        waveBar.value = e.value;
    }

    private void OnWaveReached(OnWaveReached e)
    {
        if (waveIndex < waves.Count)
        {
            waves[waveIndex].SetActive(false);
            waveIndex++;
        }
    }

    private float SetWavePosition(int waveNumber, int totalWaves)
    {
        return (FILLRECTMAXXPOSITION / 2) - (waveNumber * FILLRECTMAXXPOSITION) / (totalWaves);
    }
}
