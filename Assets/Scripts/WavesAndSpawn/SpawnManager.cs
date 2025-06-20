using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private WaveUi waveUi;
    private IWaveConfig waveConfig;
    private EnemySpawner enemySpawner;
    private IHandlePosition handlePosition;

    private int currentWaveIndex;
    private bool isSpawning;
    private bool preWaveSpawned;
    private bool isPaused;

    private const float MaxWaveBar = 100f;
    private const float WaveValueChange = -3f;

    private float waveBarProgress;
    private float waveProcent;
    private float CurrentWaveProgress
    {
        get => waveBarProgress;
        set
        {
            waveBarProgress = Mathf.Clamp(value, 0f, MaxWaveBar);
            EventBus.Publish(new WaveProgressChangeEvent(waveBarProgress / MaxWaveBar));
        }
    }

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
        waveUi = FindAnyObjectByType<WaveUi>();
        waveConfig = config;
        enemySpawner = new EnemySpawner();
        handlePosition = new RandomPositionHandler();
        waveProcent = MaxWaveBar / config.TotalWaves;
        enemySpawner.InitiateWave(transform, handlePosition);
        waveUi.InitWaves(config.TotalWaves, waveProcent / MaxWaveBar);
        CurrentWaveProgress = MaxWaveBar;
        config.InitConfig();
    }
    private IEnumerator SpawnWaves()    
    {
        //calculate waves and call to spawn it
        while (currentWaveIndex < waveConfig.TotalWaves)
        {
            if (isPaused)
                yield return null;
            float waveThreshold = MaxWaveBar - (waveProcent * (currentWaveIndex + 1));
            float preWaveThreshold = waveThreshold + (waveProcent / 2);
            if (!preWaveSpawned && CurrentWaveProgress > waveThreshold && CurrentWaveProgress <= preWaveThreshold)
            {
                preWaveSpawned = true;
                yield return SpawnWave(waveConfig.GetPreWave(currentWaveIndex), preWaveThreshold);
            }

            if (!isSpawning && CurrentWaveProgress <= waveThreshold)
            {
                preWaveSpawned = false;
                EventBus.Publish(new OnWaveReached());
                yield return SpawnWave(waveConfig.GetWave(currentWaveIndex), waveThreshold);
                currentWaveIndex++;
            }
            yield return new WaitForSeconds(1f);
        }

        //waves end trigger
        EventBus.Publish(new OnWavesEnd());
    }

    private void OnNoEnemiesDetected(NoEnemiesEvent e)
    {
        if (isSpawning) return;

        CurrentWaveProgress += WaveValueChange;
    }

    private IEnumerator SpawnWave(Wave wave, float endProgress)
    {
        isSpawning = true;

        // Visuals
        ParticleSystem waveParticle = ObjectPoolManager.FindObjectByName<ParticleSystem>("WaveParticle");
        if (waveParticle != null)
        {
            waveParticle.gameObject.SetActive(true);
            waveParticle.transform.position = transform.position;
        }

        // Copy enemies so we can modify them
        List<EnemyData> spawnEnemies = new List<EnemyData>(wave.enemies);
        int totalSpawns = enemySpawner.GetTotalEnemyCount(spawnEnemies);

        float startProgress = CurrentWaveProgress;
        bool isPrewave = startProgress > endProgress;
        float progressDelta = isPrewave ? (startProgress - endProgress) / Mathf.Max(totalSpawns, 1) : 0f;

        // Spawn loop
        while (spawnEnemies.Count > 0)
        {
            enemySpawner.SpawnEnemy(spawnEnemies);

            if (isPrewave)
            {
                CurrentWaveProgress -= progressDelta; // update bar
            }

            yield return new WaitForSeconds(wave.spawnInterwal);
        }

        isSpawning = false;
    }


    private void OnPause(OnPauseEvent e)
    {
        isPaused = e.IsPaused;
    }
}
