using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private IWaveConfig waveConfig;
    private IWaveSpawner waveSpawner;
    private IHandlePosition handlePosition;

    private int currentWaveIndex;
    private bool isSpawning;
    private bool preWaveSpawned;

    private const float MaxWaveBar = 100f;
    private float currentWaveBarProgress;
    private const float WaveValueChange = -5f;
    private bool isPaused = false;

    private float WavePercentage => MaxWaveBar / waveConfig.TotalWaves;

    public void Init(IWaveConfig config)
    {
        waveConfig = config;
        waveSpawner = new WaveSpawner();
        handlePosition = new RandomPositionHandler();
        waveSpawner.InitiateWave(transform, handlePosition);
        currentWaveBarProgress = MaxWaveBar;
        config.GetAllEnemyTypesInitiate();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        BulletBehaivior bullet = collision.GetComponent<BulletBehaivior>();
        if (bullet != null)
        {
            bullet.Deactivate();
        }
    }

    public void StartSpawning() => StartCoroutine(SpawnWaves());

    private void OnEnable()
    {
        EventBus.Subscribe<NoEnemiesEvent>(OnNoEnemiesDetected);
        EventBus.Subscribe<OnPauseEvent>(StopSpawning, 1);
        EventBus.Subscribe<OnResumeEvent>(ResumeSpawing, 1);
    }
    private void OnDisable()
    {
        EventBus.UnSubscribe<NoEnemiesEvent>(OnNoEnemiesDetected);
        EventBus.UnSubscribe<OnPauseEvent>(StopSpawning);
        EventBus.UnSubscribe<OnResumeEvent>(ResumeSpawing);
    }

    private IEnumerator SpawnWaves()
    {
        while (currentWaveIndex < waveConfig.TotalWaves)
        {
            if (isPaused)
                yield return null;
            float waveThreshold = MaxWaveBar - (WavePercentage * (currentWaveIndex + 1));
            float preWaveThreshold = waveThreshold + (WavePercentage / 2);

            if (!preWaveSpawned && currentWaveBarProgress > waveThreshold && currentWaveBarProgress <= preWaveThreshold)
            {
                preWaveSpawned = true;
                yield return SpawnWave(waveConfig.GetPreWave(currentWaveIndex));
            }

            if (!isSpawning && currentWaveBarProgress <= waveThreshold)
            {
                preWaveSpawned = false;
                EventBus.Publish(new OnWaveReached());
                yield return SpawnWave(waveConfig.GetWave(currentWaveIndex));
                currentWaveIndex++;
            }
            yield return new WaitForSeconds(1f);
        }
    }

    private void OnNoEnemiesDetected(NoEnemiesEvent e)
    {
        if (isSpawning) return;

        currentWaveBarProgress += WaveValueChange;
        EventBus.Publish(new WaveProgressChangeEvent(currentWaveBarProgress));
    }
    
    private IEnumerator SpawnWave(Wave wave)
    {
        isSpawning = true;
        yield return waveSpawner.SpawnEnemies(wave);
        isSpawning = false;
    }

    private void StopSpawning(OnPauseEvent e)
    {
        isPaused = true;
    }

    private void ResumeSpawing(OnResumeEvent e)
    {
        isPaused = false;
    }
}
