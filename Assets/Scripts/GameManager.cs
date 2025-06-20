using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private LoseMenu lostMenu;
    [SerializeField] private WinMenu winMenu;

    private SpawnManager spawnManager;
    private Button pauseButton;
    private LevelConfig config;
    private LevelStatsTracker levelStatsTracker;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            Init();
            SubscribeEvents();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        StartGame();
    }

    private void OnDestroy()
    {
        UnsubscribeEvents();
    }

    private void Init()
    {
        pauseButton = GameObject.Find("PauseButton")?.GetComponent<Button>();
        config = LevelRegister.GetCurrentLevelConfig();
        spawnManager = FindAnyObjectByType<SpawnManager>();
        levelStatsTracker = new LevelStatsTracker();

        if (config != null)
        {
            config.CollectablesConfig.Init();
            CollectablesSpawn.Init(config.CollectablesConfig);
            spawnManager?.Init(config.WavesConfig);
        }
    }

    private void SubscribeEvents()
    {
        EventBus.Subscribe<OnPauseEvent>(TimeManager);
        EventBus.Subscribe<OnWinEvent>(WinGame);
        EventBus.Subscribe<PlayerDieEvent>(LostGame);
        EventBus.Subscribe<OnDamageTakeEvent>(DetectTakenDamage);
        UpdateSystem.CallUpdate += Tick;
    }

    private void UnsubscribeEvents()
    {
        EventBus.UnSubscribe<OnPauseEvent>(TimeManager);
        EventBus.UnSubscribe<OnWinEvent>(WinGame);
        EventBus.UnSubscribe<PlayerDieEvent>(LostGame);
        EventBus.UnSubscribe<OnDamageTakeEvent>(DetectTakenDamage);
        UpdateSystem.CallUpdate -= Tick;
    }

    public void StartGame()
    {
        InventoryManager.Instance?.CreateInventory();
        UpdateSystem.Initialize();
        levelStatsTracker?.OnStart();
        spawnManager?.StartSpawning();
    }

    private void Tick()
    {
        levelStatsTracker?.OnUpdate(Time.deltaTime);
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
        Time.timeScale = e.IsPaused ? 0f : 1f;
    }

    public void Replay()
    {
        ResumeGame();
        ObjectPoolManager.ClearObjectsFromPool();
        EventBus.ClearBus();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Exit()
    {
        ResumeGame();
        ObjectPoolManager.ClearObjectsFromPool();
        EventBus.ClearBus();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    private void WinGame(OnWinEvent e)
    {
        levelStatsTracker?.OnFinish();
        ReviewSet();
        PauseGame();
    }

    public void LostGame(PlayerDieEvent e)
    {
        pauseButton.interactable = false;
        levelStatsTracker?.OnFinish();
        ReviewSet();
        PauseGame();
    }

    private void DetectTakenDamage(OnDamageTakeEvent e)
    {
        levelStatsTracker?.OnDamageTaken(e.damage);
    }

    private void ReviewSet()
    {
        var stats = levelStatsTracker.GetResults();
        int stars = SetStars();

        if (stars > 0)
        {
            winMenu?.ShowMenu(stars, stats.TimeSpent, stats.DamageTaken);
            config?.CompleteLevel(stars);
            LevelRegister.UnlockNextLevel();
        }
        else
        {
            lostMenu?.ShowMenu(stars, stats.TimeSpent, stats.DamageTaken);
        }
    }

    private int SetStars()
    {
        int damage = levelStatsTracker.GetResults().DamageTaken;

        if (damage <= config.levelRequirements.threeStarsDamage)
            return 3;
        else if (damage <= config.levelRequirements.twoStarsDamage)
            return 2;
        else if (damage <= config.levelRequirements.oneStarsDamage)
            return 1;

            return 0;
    }
}
