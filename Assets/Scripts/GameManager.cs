using System.ComponentModel;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private LevelConfig levelConfig;
     public static GameManager instance;
     private SpawnManager spawnManager;
     private Button pauseButton;
     private MenuSlide lostMenu, winMenu;

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
        lostMenu.gameObject.SetActive(true);
        lostMenu.ShowPauseMenu();
        PauseGame();
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
        winMenu.gameObject.SetActive(true);
        winMenu.ShowPauseMenu();
        PauseGame();
        LevelRegister.UnlockNextLevel();
    }

    private void Init()
    {
        pauseButton = GameObject.Find("PauseButton").GetComponent<Button>();
        lostMenu = GameObject.Find("LostMenu").GetComponent<MenuSlide>();
        lostMenu.gameObject.SetActive(false);
        winMenu = GameObject.Find("WonMenu").GetComponent<MenuSlide>();
        winMenu.gameObject.SetActive(false);
        LevelConfig config = LevelRegister.GetLevelConfig();
        if (config == null)
        {
            config = levelConfig;
        }

        spawnManager = GameObject.FindAnyObjectByType<SpawnManager>();
        CollectablesSpawn.Init(config.CollectablesConfig);
        spawnManager.Init(config.WavesConfig);
    }

    void Awake()
    {
        Init();
        EventBus.Subscribe<OnPauseEvent>(TimeManager);
        EventBus.Subscribe<OnWinEvent>(WinGame);
        EventBus.Subscribe<PlayerDieEvent>(LostGame);


        if (instance ==null)
        {
            instance = this;
        }
    }

    void OnDestroy()
    {
        EventBus.UnSubscribe<OnWinEvent>(WinGame);
        EventBus.UnSubscribe<OnPauseEvent>(TimeManager);
        EventBus.UnSubscribe<PlayerDieEvent>(LostGame);
    }

}
