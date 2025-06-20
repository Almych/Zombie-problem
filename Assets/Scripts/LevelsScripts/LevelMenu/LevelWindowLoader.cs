using UnityEngine;

public class LevelWindowLoader : MonoBehaviour
{
    [SerializeField] private LevelWindow levelWindow;

    private void Awake()
    {
        EventBus.Subscribe<OnLevelClickEvent>(ShowWindow);
    }

    private void Start()
    {
        LevelRegister.GetCurrentLevel();
    }

    private void OnDestroy()
    {
        EventBus.UnSubscribe<OnLevelClickEvent>(ShowWindow);
    }

    private void ShowWindow(OnLevelClickEvent e)
    {
        Debug.Log(e.LevelConfig.IsOpen);
        if (!e.LevelConfig.IsOpen)
            return;

        levelWindow.gameObject.SetActive(true);
        levelWindow.SetLevelData(e.LevelConfig);
    }
}
