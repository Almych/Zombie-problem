using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelInfo : MonoBehaviour
{
    [SerializeField] private LevelConfig levelConfig;
    private Button levelButton;
    void Awake()
    {
        levelButton = GetComponent<Button>();
        EventBus.Subscribe<OnLevelUnlock>(OnUnlock);
        levelButton.onClick.AddListener(ShowLevelWindow);
    }

    void OnDestroy()
    {
        EventBus.UnSubscribe<OnLevelUnlock>(OnUnlock);
    }

    private void ShowLevelWindow()
    {
        EventBus.Publish(new OnLevelClickEvent(levelConfig));
    }

    private void OnUnlock(OnLevelUnlock e)
    {
        levelConfig.TryOpenLevel(e.level);
    }
}
