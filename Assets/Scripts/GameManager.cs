using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private LevelConfig config;
    [SerializeField] private SpawnManager spawnManager;
    [SerializeField] private WaveUi waveUi;
    public void PauseGame()
    {

    }
    void Start()
    {
        EventBus.Publish(new InitiateEvent());
        waveUi.InitWaves(config.WavesConfig.TotalWaves);
        CollectablesSpawn.Init(config.CollectablesConfig);
        spawnManager.StartSpawning();
    }
    public void StartGame()
    {

    }

    public void LostGame()
    {

    }

    public void ResumeGame()
    {

    }

    void Awake()
    {
        spawnManager.Init(config.WavesConfig);
        
    }
}
