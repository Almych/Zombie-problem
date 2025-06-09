using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelWindow : MonoBehaviour
{
    [SerializeField] private TMP_Text titleText;
    [SerializeField] private TMP_Text descriptionText;
    [SerializeField] private Image levelDayImage;
    [SerializeField] private Sprite daySprite, nightSprite, eveningSprite;

    public void SetLevelData(LevelConfig config)
    {
        titleText.text = config.Title;
        descriptionText.text = config.Description;
        SetDay(config.levelDay);
        LevelRegister.SetCurrentLevel(config);
    }

    private void SetDay(LevelDay levelDay)
    {
        levelDayImage.sprite = levelDay switch
        {
            LevelDay.Day => daySprite,
            LevelDay.Night => nightSprite,
            LevelDay.Evening => eveningSprite,
            _ => levelDayImage.sprite
        };
    }
}
