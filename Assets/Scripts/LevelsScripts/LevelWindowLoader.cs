
using UnityEngine;

public class LevelWindowLoader : MonoBehaviour
{
    [SerializeField]private LevelWindow levelWindow;
    private static bool isCalled;
    
    private void Awake()
    {
        if (!isCalled)
        {
            LevelRegister.UnlockNextLevel();
            isCalled = true;
        }
        EventBus.Subscribe<OnLevelClickEvent>(ShowWindow);
    }

    private void OnDestroy()
    {
        EventBus.UnSubscribe<OnLevelClickEvent>(ShowWindow);
    }

    private void ShowWindow(OnLevelClickEvent e)
    {
        levelWindow.gameObject.SetActive(true);
        levelWindow.SetLevelData(e.LevelConfig);
    }
}
