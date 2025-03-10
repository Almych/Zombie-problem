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
        EventBus.Publish(new OnPauseEvent());
        StopTime();
    }

    void Start()
    {
        waveUi.InitWaves(config.WavesConfig.TotalWaves);
        EventBus.Publish(new InitiateEvent());
        CollectablesSpawn.Init(config.CollectablesConfig);
        spawnManager.StartSpawning();
        TickSystem.Initialize();
    }
    public void StartGame()
    {

    }

    public void LostGame()
    {

    }

    public void ResumeGame()
    {
        EventBus.Publish(new OnResumeEvent());
        ResumeTime();
    }

    void Awake()
    {
        spawnManager.Init(config.WavesConfig);
    }
    private void StopTime()
    {
        Time.timeScale = 0f;
    }

    private void ResumeTime()
    {
        Time.timeScale = 1;
    }
}
