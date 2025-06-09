using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.UI;
public class MenuSlide : MonoBehaviour
{
    [SerializeField] private Sprite emptyStarSprite;
    [SerializeField] private Sprite filledStarSprite;
    public float transitionDuration = 0.5f;
    [SerializeField] private TMP_Text time, takenDamage;
    [SerializeField] private Image[] starsIcons = new Image[3];
    private Vector2 hiddenPosition;
    private RectTransform menu;
    private Vector2 shownPosition = Vector2.zero; 

    private void Awake()
    {
        menu = GetComponent<RectTransform>();
        hiddenPosition = new Vector2(0, -Screen.height); 
        menu.anchoredPosition = hiddenPosition;
    }

    public void ShowMenu()
    {
        gameObject.SetActive(true);
        menu.DOAnchorPos(shownPosition, transitionDuration)
            .SetEase(Ease.OutExpo).SetUpdate(true);
        Time.timeScale = 0f;
    }

    public void HidePauseMenu()
    {
        gameObject.SetActive(false);
        menu.DOAnchorPos(hiddenPosition, transitionDuration)
            .SetEase(Ease.InExpo).SetUpdate(true)
            .OnComplete(() => gameObject.SetActive(false));
        Time.timeScale = 1f;
    }
    public void ShowFinishedMenu(int stars)
    {
        ShowMenu();
        AnimateStars(stars);
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
