using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private LevelConfig config;
    [SerializeField] private SpawnManager spawnManager;

    void Start()
    {
        StartGame();
    }
    public void StartGame()
    {
        TickSystem.Initialize();
        spawnManager.StartSpawning();
    }

    public void LostGame()
    {

    }
    public void PauseGame()
    {
        EventBus.Publish(new OnPauseEvent(true));
        Time.timeScale = 0f;
    }
    public void ResumeGame()
    {
        EventBus.Publish(new OnPauseEvent(false));
        Time.timeScale = 1;
    }

    void Awake()
    {
        CollectablesSpawn.Init(config.CollectablesConfig);
        spawnManager.Init(config.WavesConfig);
    }
    
  
}
