using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class WaveManager : MonoBehaviour
{

    [Header("Has max amount of the waves(5)")]
    public static WaveManager Instance;
    public event Action<float> onWaveProgress;
    public event Action<int> onWaveReach;
    public EnemyWave[] enemyWaves = new EnemyWave[5];
    public WaveUi waveUi;
    private const float waveBar = 100f;
    private float currentTime = 0;
    private SpawnStateMachine spawnStateMachine;
    private const float waveSpawnInterval = 5f;
    private List<float> wavesPercents;
    private bool[] wavesCalled, preWavesCalled;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        spawnStateMachine = new SpawnStateMachine(this);
        wavesPercents = GetWaveProcent();
        GetEnemySpices(enemyWaves);
        wavesCalled = new bool[wavesPercents.Count];
        preWavesCalled = new bool[wavesPercents.Count];
        waveUi.InitWaves(wavesPercents, enemyWaves.Length);
        DefeatedEnemyTrigger.Instance.Initiate();
        StartCoroutine(StartToSpawn());
    }

    public IEnumerator StartToSpawn()
    {
        while (currentTime <= 100)
        {
            yield return new WaitForSeconds(waveSpawnInterval);
            CheckWave();
        }
        DefeatedEnemyTrigger.Instance.StopCheckForEnemies();
    }



    private void CheckWave()
    {
        for (int i = 0; i < wavesPercents.Count; i++)
        {
            if (currentTime >= wavesPercents[i] && !wavesCalled[i] &&  !spawnStateMachine.spawnPreWaveState.isRunning)
            {
                Debug.Log("Wave");
                spawnStateMachine.SwitchState(spawnStateMachine.spawnWaveState, enemyWaves[i].wave);
                wavesCalled[i] = true;
                onWaveReach?.Invoke(i);
            }
            else if (currentTime < wavesPercents[i] && !wavesCalled[i] && !spawnStateMachine.spawnWaveState.isRunning && !preWavesCalled[i])
            {
                Debug.Log("Prewave");
                spawnStateMachine.SwitchState(spawnStateMachine.spawnPreWaveState, enemyWaves[i].preWave);
                preWavesCalled[i] = true;
            }
        }
    }

    private void OnEnable()
    {
        DefeatedEnemyTrigger.Instance.GetActiveEnemies += IncreaseWaveProgress;

    }

    private void OnDisable()
    {
        DefeatedEnemyTrigger.Instance.GetActiveEnemies -= IncreaseWaveProgress;
    }


    private void GetEnemySpices(EnemyWave[] enemyWaves)
    {
        HashSet<Entity> spices = new HashSet<Entity>();
        foreach (var enemies in enemyWaves)
        {
            foreach (var waveEnemy in enemies.wave)
            {
                if (!spices.Contains(waveEnemy.enemyType))
                {
                    spices.Add(waveEnemy.enemyType);
                }
            }

            foreach (var preEnemy in enemies.preWave)
            {
                if (!spices.Contains(preEnemy.enemyType))
                {
                    spices.Add(preEnemy.enemyType);
                }
            }
        }
        foreach (var enemy in spices)
        {
            ObjectPoolManager.CreateObjectPool(enemy, 5);
        }

    }
    private List<float> GetWaveProcent()
    {
        List<float> wavePercents = new List<float>();
        for (int i = 1; i <= enemyWaves.Length; i++)
        {
            float percentWave = (waveBar / enemyWaves.Length) * i;
            wavePercents.Add(percentWave);
        }
        return wavePercents;
    }

    private void IncreaseWaveProgress()
    {
        currentTime += 5;
        Debug.Log(currentTime);
        onWaveProgress?.Invoke(currentTime);
    }


}
