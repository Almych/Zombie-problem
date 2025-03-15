using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private WaveUi waveUi;
    private IWaveConfig waveConfig;
    private IEnemySpawner enemySpawner;
    private IHandlePosition handlePosition;

    private int currentWaveIndex;
    private bool isSpawning;
    private bool preWaveSpawned;

    private const float MaxWaveBar = 100f;
    private float currentWaveBarProgress;
    private const float WaveValueChange = -5f;
    private bool isPaused = false;

    private float WavePercentage => MaxWaveBar / waveConfig.TotalWaves;

    private void Awake()
    {
        EventBus.Subscribe<NoEnemiesEvent>(OnNoEnemiesDetected);
        EventBus.Subscribe<OnPauseEvent>(OnPause, 1);
    }
    private void OnDestroy()
    {
        EventBus.UnSubscribe<NoEnemiesEvent>(OnNoEnemiesDetected);
        EventBus.UnSubscribe<OnPauseEvent>(OnPause);
    }
    public void StartSpawning() => StartCoroutine(SpawnWaves());
    public void Init(IWaveConfig config)
    {
        waveConfig = config;
        enemySpawner = new EnemySpawner();
        handlePosition = new RandomPositionHandler();
        enemySpawner.InitiateWave(transform, handlePosition);
        currentWaveBarProgress = MaxWaveBar;
        waveUi.InitWaves(config.TotalWaves);
        config.GetAllEnemyTypesInitiate();
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
        yield return enemySpawner.SpawnEnemies(wave);
        isSpawning = false;
    }

    private void OnPause(OnPauseEvent e)
    {
        isPaused = e.IsPaused;
    }
}
