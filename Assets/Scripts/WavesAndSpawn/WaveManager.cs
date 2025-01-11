using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UIElements;

public class WaveManager : MonoBehaviour
{

    [Header("Has max amount of the waves(5)")]
    [SerializeField] private EnemyWave[] enemyWaves = new EnemyWave[5];
    [SerializeField] private WaveUi waveUi;
    private const float waveBar = 100f;
    private float currentTime = 0;
    private SpawnStateMachine spawnStateMachine;
    private const float waveSpawnInterval = 2f;
    private bool isSpawning = false;
    private List<float> wavesPercents;
    private List<bool> wavesCalled;
    private void Start()
    {
        spawnStateMachine = new SpawnStateMachine(this);
        GetEnemySpices(enemyWaves);
        var waves = GetWaves();
        wavesPercents = new List<float>(waves.Keys);
        wavesCalled = new List<bool>(waves.Values);
        DefeatedEnemyTrigger.Instance.Initiate();
        waveUi.InitWaves(enemyWaves.Length);
        StartCoroutine(StartToSpawn());
    }

    public IEnumerator StartToSpawn()
    {
        while (currentTime <= 100)
        {
            Debug.Log(isSpawning);
            Debug.Log(currentTime);
            yield return new WaitForSeconds(waveSpawnInterval);
            CheckWave();
        }
    }

    private void OnEnable()
    {
        DefeatedEnemyTrigger.Instance.GetActiveEnemies += () => { currentTime += 5; };
    }

    private void OnDisable()
    {
        DefeatedEnemyTrigger.Instance.GetActiveEnemies -= () => { currentTime += 5; };
    }

    private void CheckWave()
    {
        
        for (int i = 0; i < wavesPercents.Count; i++)
        {
            float wavePercent = wavesPercents[i];
            if (currentTime >= wavePercent && wavesCalled[i] && spawnStateMachine.currentState == spawnStateMachine.spawnPreWaveState && !spawnStateMachine.spawnPreWaveState.isRunning)
            {
                isSpawning = true;
                Debug.Log("Wave");
                spawnStateMachine.SwitchState(spawnStateMachine.spawnWaveState,enemyWaves[i].wave);
                wavesCalled[i] = false;  
            }
            else if (currentTime < wavePercent && wavesCalled[i] && spawnStateMachine.currentState != spawnStateMachine.spawnPreWaveState)
            {
                isSpawning = true;
                Debug.Log("Prewave");
                spawnStateMachine.SwitchState(spawnStateMachine.spawnPreWaveState, enemyWaves[i].preWave);
            }
        }
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
            EnemyPool.Instance.InitiateEnemy(enemy);
        }

    }

    private float GetWaveProcent()
    {
        float percentWave = waveBar / enemyWaves.Length;
        return percentWave;
    }

    private int GetWaveAmount()
    {
        float amount = waveBar / GetWaveProcent();
        return int.Parse(amount.ToString());
    }

    private Dictionary<float, bool> GetWaves()
    {
        Dictionary<float, bool> waves = new Dictionary<float, bool>();

        for (int i = 1; i <= GetWaveAmount(); i++)
        {
            waves.Add(GetWaveProcent() * i, true);
        }

        return waves;
    }



}
