using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UIElements;
[Serializable]
public struct WaveData
{
    public EnemyData[] wave;
    public EnemyData[] preWave;
}

public class WaveManager : MonoBehaviour
{

    [Header("Has max amount of the waves(5)")]
    public static WaveManager Instance;
    public WaveData[] waveDatas;
    private const float waveBar = 100f;
    private float currentTime = 0;
    private SpawnStateMachine spawnStateMachine;
    private const float waveSpawnInterval = 2f;
    private List<float> wavesPercents;
    private List<bool> wavesCalled;


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
        var waves = GetWaves();
        wavesPercents = new List<float>(waves.Keys);
        wavesCalled = new List<bool>(waves.Values);
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
    }



    private void CheckWave()
    {
        
        for (int i = 0; i < wavesPercents.Count; i++)
        {
            float wavePercent = wavesPercents[i];
            if (currentTime >= wavePercent && wavesCalled[i] && spawnStateMachine.currentState == spawnStateMachine.spawnPreWaveState && !spawnStateMachine.spawnPreWaveState.isRunning)
            {
                Debug.Log("Wave");
                spawnStateMachine.SwitchState(spawnStateMachine.spawnWaveState,enemyWaves[i].wave);
                wavesCalled[i] = false;  
            }
            else if (currentTime < wavePercent && wavesCalled[i] && spawnStateMachine.currentState != spawnStateMachine.spawnPreWaveState)
            {
                Debug.Log("Prewave");
                spawnStateMachine.SwitchState(spawnStateMachine.spawnPreWaveState, enemyWaves[i].preWave);
            }
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
        float percentWave = waveBar / waveDatas.Length;
        return percentWave;
    }

    private int GetWaveAmount()
    {
        float amount = waveBar / GetWaveProcent();
        return int.Parse(amount.ToString());
    }

    private List<EnemyWave> GetEnemyWaves()
    {
        List<EnemyWave> enemyWaves = new List<EnemyWave>();

        for (int i = 0; i < GetWaveAmount(); i++)
        {
            EnemyWave enemyWave = new EnemyWave(waveDatas[i].wave, waveDatas[i].preWave, GetWaveProcent());
            enemyWaves.Add(enemyWave);
        }

        return enemyWaves;
    }


}
