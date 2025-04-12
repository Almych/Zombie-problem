
using UnityEngine;

public class LevelWindowLoader : MonoBehaviour
{
    [SerializeField]private LevelWindow levelWindow;
    
    private void Awake()
    {
        EventBus.Subscribe<OnLevelClickEvent>(ShowWindow);
    }

    void Start()
    {
        LevelRegister.GetCurrentLEvel();
    }

    private void OnDestroy()
    {
        EventBus.UnSubscribe<OnLevelClickEvent>(ShowWindow);
    }
    //activate level window and set data to it
    private void ShowWindow(OnLevelClickEvent e)
    {
        if (!e.LevelConfig.levelOpen)
            return;
        levelWindow.gameObject.SetActive(true);
        levelWindow.SetLevelData(e.LevelConfig);
    }
}
