using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WinMenu : BaseMenu
{
    [SerializeField] private Sprite emptyStarSprite;
    [SerializeField] private Sprite filledStarSprite;
    [SerializeField] private TMP_Text time, takenDamage;
    [SerializeField] private Image[] starsIcons = new Image[3];

    public override void ShowMenu(int stars = 0, float timeSpent = 0, int damageTaken = 0)
    {
        base.ShowMenu(stars, timeSpent, damageTaken);
        AnimateStars(stars);
        time.text = $"{timeSpent:F1}s";
        takenDamage.text = $"{damageTaken}";
    }

    private void AnimateStars(int starsEarned)
    {
        for (int i = 0; i < starsIcons.Length; i++)
        {
            Image star = starsIcons[i];
            star.gameObject.SetActive(true);

            if (i < starsEarned)
            {
                star.sprite = filledStarSprite;
                star.transform.localScale = Vector3.zero;
                star.transform.DOScale(Vector3.one, 0.4f)
                    .SetEase(Ease.OutBack)
                    .SetDelay(i * 0.2f)
                    .SetUpdate(true);
            }
            else
            {
                star.sprite = emptyStarSprite;
                star.transform.localScale = Vector3.one;
            }
        }
    }
}
