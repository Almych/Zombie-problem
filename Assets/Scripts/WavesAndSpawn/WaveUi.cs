using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;


public class WaveUi : MonoBehaviour
{
    [SerializeField] private Slider waveBar;
    [SerializeField] private GameObject wavePrefab;
    private const float FILLRECTMAXXPOSITION = 260f;
    private List<GameObject> waves = new List<GameObject>();
    public void ChangeWaveBarValue(float value)
    {
        waveBar.value = value;
    }

    public void OnWaveCall(int waveCount)
    {
         waves[waveCount].SetActive(false);
    }

    public async void InitWaves(List<float> waveProcents, int waveMaxAmount)
    {
        Vector3 scale = wavePrefab.GetComponent<RectTransform>().localScale;
        var fill = waveBar.fillRect.parent.GetComponent<RectTransform>();

        for (int i = 0; i < waveMaxAmount; i++)
        {
            GameObject wave = Instantiate(wavePrefab);
            wave.transform.SetParent(fill);
            var rect = wave.GetComponent<RectTransform>();
            float wavePosition = await GetWavePosition(waveProcents[i]);

           rect.localPosition = new Vector2(wavePosition, fill.localPosition.y);
           rect.localScale = scale;

            waves.Add(wave);
        }

    }


    private async Task<float> GetWavePosition(float percent)
    {
        return await Task.Run(() =>
        {
            float n = FILLRECTMAXXPOSITION * percent / 100;
            float value = FILLRECTMAXXPOSITION - n;
            return value - FILLRECTMAXXPOSITION / 2;
        });
    }

}
