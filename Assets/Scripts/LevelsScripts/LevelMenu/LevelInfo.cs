using UnityEngine;
using UnityEngine.UI;

public class LevelInfo : MonoBehaviour
{
    [SerializeField] private LevelConfig levelConfig;
    [SerializeField] private GameObject starsContainer,lockContainer;
    [SerializeField] private Sprite filledStar;
    [SerializeField] private Image[] stars  =  new Image[3];
    private Button levelButton;

    private void Awake()
    {
        levelButton = GetComponent<Button>();
        EventBus.Subscribe<OnLevelUnlock>(OnUnlock);
        levelButton.onClick.AddListener(OnClick);
       
    }

    private void OnDestroy()
    {
        EventBus.UnSubscribe<OnLevelUnlock>(OnUnlock);
    }

    private void UpdateInfo(int level)
    {
        if (level < levelConfig.LevelId)
        {
            lockContainer.SetActive(true);
            starsContainer.SetActive(false);
        }
        else
        {
            lockContainer.SetActive(false);
            starsContainer.SetActive(true);
            if (levelConfig.IsCompleted)
            {
                for (int i = 0; i < levelConfig.StarsEarned; i++)
                {
                    stars[i].sprite = filledStar;
                }
            }
        }

    }

    private void OnClick()
    {
        EventBus.Publish(new OnLevelClickEvent(levelConfig));
    }

    private void OnUnlock(OnLevelUnlock e)
    {
        levelConfig.TryOpen(e.level);
        UpdateInfo(e.level);
    }
}
