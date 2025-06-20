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
        EventBus.Subscribe<OnLevelUnlockEvent>(OnUnlock);
        levelButton.onClick.AddListener(OnClick);
       
    }

    private void OnDestroy()
    {
        EventBus.UnSubscribe<OnLevelUnlockEvent>(OnUnlock);
    }

    private void UpdateInfo()
    {
        levelConfig.LoadProgress();

        if (!levelConfig.IsOpen)
        {
            lockContainer.SetActive(true);
            starsContainer.SetActive(false);
            return;
        }

        lockContainer.SetActive(false);
        starsContainer.SetActive(true);


        for (int i = 0; i < levelConfig.StarsEarned; i++)
        {
            stars[i].enabled = true;
            stars[i].sprite = filledStar;
        }
    }


    private void OnClick()
    {
        EventBus.Publish(new OnLevelClickEvent(levelConfig));
    }

    private void OnUnlock(OnLevelUnlockEvent e)
    {
        levelConfig.TryOpen(e.levelReached);
        UpdateInfo();
    }
}
