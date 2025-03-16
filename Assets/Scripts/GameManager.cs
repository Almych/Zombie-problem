using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private LevelConfig config;
    [SerializeField] private SpawnManager spawnManager;
    [SerializeField] private Button pauseButton;
    void Start()
    {
        StartGame();
    }
    public void StartGame()
    {
        UpdateSystem.Initialize();
        spawnManager.StartSpawning();
    }

    public void LostGame(PlayerDieEvent e)
    {
        pauseButton.interactable = false;
    }
    public void PauseGame()
    {
        EventBus.Publish(new OnPauseEvent(true));
    }
    public void ResumeGame()
    {
        EventBus.Publish(new OnPauseEvent(false));
    }

    private void TimeManager(OnPauseEvent e)
    {
        if (e.IsPaused)
        {
            Time.timeScale = 0f;
        }else
        {
            Time.timeScale = 1f;
        }
    }


    void Awake()
    {
        CollectablesSpawn.Init(config.CollectablesConfig);
        spawnManager.Init(config.WavesConfig);
        EventBus.Subscribe<OnPauseEvent>(TimeManager);
        EventBus.Subscribe<PlayerDieEvent>(LostGame);
    }

    void OnDestroy()
    {
        EventBus.UnSubscribe<OnPauseEvent>(TimeManager);
        EventBus.UnSubscribe<PlayerDieEvent>(LostGame);
    }

}
