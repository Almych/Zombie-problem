using System.ComponentModel;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private LevelConfig config;
     public static GameManager instance;
     private SpawnManager spawnManager;
     private Button pauseButton;
     private LevelConfig levelCOnf => config;
     private LevelStatsTracker levelStatsTracker;
     [SerializeField]private LoseMenu lostMenu;
     [SerializeField] private WinMenu winMenu;


    void Awake()
    {
        Init();
        EventBus.Subscribe<OnPauseEvent>(TimeManager);
        EventBus.Subscribe<OnWinEvent>(WinGame);
        EventBus.Subscribe<PlayerDieEvent>(LostGame);
        EventBus.Subscribe<OnDamageTakeEvent>(DetectTakenDamage);
        UpdateSystem.CallUpdate += Tick;


        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        StartGame();
    }
    void OnDestroy()
    {
        EventBus.UnSubscribe<OnWinEvent>(WinGame);
        EventBus.UnSubscribe<OnPauseEvent>(TimeManager);
        EventBus.UnSubscribe<PlayerDieEvent>(LostGame);
        EventBus.UnSubscribe<OnDamageTakeEvent>(DetectTakenDamage);
        UpdateSystem.CallUpdate -= Tick;
    }


    private void Init()
    {
        pauseButton = GameObject.Find("PauseButton").GetComponent<Button>();
        if (config == null)
            config = LevelRegister.GetCurrentLevelConfig();
        spawnManager = FindAnyObjectByType<SpawnManager>();
        levelStatsTracker = new LevelStatsTracker();
        config.CollectablesConfig.Init();
        CollectablesSpawn.Init(config.CollectablesConfig);
        spawnManager.Init(config.WavesConfig);
    }

    public void StartGame()
    {
        InventoryManager.Instance.CreateInventory();
        UpdateSystem.Initialize();
        levelStatsTracker.OnStart();
        spawnManager.StartSpawning();
    }

    public void LostGame(PlayerDieEvent e)
    {
        pauseButton.interactable = false;
        levelStatsTracker.OnFinish();
        var stats = levelStatsTracker.GetResults();
        lostMenu.ShowMenu(0, stats.TimeSpent, stats.DamageTaken);
        PauseGame();
    }

    private void Tick()
    {
        levelStatsTracker?.OnUpdate(Time.deltaTime);
    }

    private void ReviewSet()
    {
        var stats = levelStatsTracker.GetResults();
        int stars = SetStars();
        winMenu.ShowMenu(stars, stats.TimeSpent, stats.DamageTaken);
        config.CompleteLevel(stars);
        LevelRegister.UnlockNextLevel();
    }

  


    private int SetStars()
    {
        int damage = levelStatsTracker.GetResults().DamageTaken;

        if (damage <= config.levelRequirements.threeStarsDamage)
            return 3;
        else if (damage <= config.levelRequirements.twoStarsDamage)
            return 2;
        else
            return 1;
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

    public void Replay()
    {
        EventBus.Publish(new OnPauseEvent(false));
        ObjectPoolManager.ClearObjectsFromPool();
        EventBus.ClearBus();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Exit()
    {
        EventBus.Publish(new OnPauseEvent(false));
        ObjectPoolManager.ClearObjectsFromPool();
        EventBus.ClearBus();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-1);
    }



    private void WinGame(OnWinEvent e)
    {
        PauseGame();
        levelStatsTracker.OnFinish();
        ReviewSet();
    }

   

    private void DetectTakenDamage(OnDamageTakeEvent e)
    {
        levelStatsTracker?.OnDamageTaken(e.damage);
    }

}
