using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveUi : MonoBehaviour
{
    [SerializeField] private GameObject wavePrefab;
     private Image waveBar;

    private float fillMaxPosition;
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

    public void InitWaves(int waveMaxAmount, float waveProcent)
    {               
        waveBar = GetComponent<Image>();
        fillMaxPosition = waveBar.rectTransform.rect.width;
        waveStep = fillMaxPosition * waveProcent;
        Vector3 scale = new Vector2(waveBar.rectTransform.rect.height * 2, waveBar.rectTransform.rect.height * 2);
        RectTransform fill = waveBar.rectTransform;

        for (int i = 1; i <= waveMaxAmount; i++)
        {
            GameObject wave = Instantiate(wavePrefab, fill);
            RectTransform rect = wave.GetComponent<RectTransform>();
            
            rect.anchoredPosition = new Vector2(SetWavePosition(i), rect.anchoredPosition.y);
            rect.sizeDelta = scale;

            waves.Add(wave);
        }
    }

    public void ChangeWaveBarValue(WaveProgressChangeEvent e)
    {
        if (waveBar != null)
        {
            waveBar.fillAmount = Mathf.Clamp01(e.value); 
        }
    }

    private void OnWaveReached(OnWaveReached e)
    {
        if (waveIndex < waves.Count)
        {
            waves[waveIndex].SetActive(false);
            waveIndex++;
        }
    }

    private float SetWavePosition(int waveNumber)
    {
        return (fillMaxPosition / 2) - (waveNumber  * waveStep);
    }
}
