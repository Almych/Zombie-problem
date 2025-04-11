
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelWindow : MonoBehaviour
{
    [SerializeField] private Sprite daySprite, nightSprite, eveningSprite;
    [SerializeField] private TMP_Text titleText, descriptionText;
    [SerializeField] private Image levelDayImage;
    public void SetLevelData(LevelConfig config)
    {
        titleText.text = config.Title;
        descriptionText.text = config.Description;
        SetDay(config.levelDay);
        LevelRegister.SetLevelConfig(config);
    }

    private void SetDay(LevelDay levelDay)
    {
        switch(levelDay)
        {
            case LevelDay.Day:
                levelDayImage.sprite = daySprite;
                break;
            case LevelDay.Night:
                levelDayImage.sprite = nightSprite;
                break;

            case LevelDay.Evening:
                levelDayImage.sprite = eveningSprite;
                break;
            default:
                break;
        }
    }
}
