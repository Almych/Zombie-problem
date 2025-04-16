
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
        int lvel = LevelRegister.GetCurrentLEvel();
    }

    private void OnDestroy()
    {
        EventBus.UnSubscribe<OnLevelClickEvent>(ShowWindow);
    }


    private void ShowWindow(OnLevelClickEvent e)
    {
        if (!e.LevelConfig.levelOpen)
            return;

        levelWindow.gameObject.SetActive(true);
        levelWindow.SetLevelData(e.LevelConfig);
    }
}
