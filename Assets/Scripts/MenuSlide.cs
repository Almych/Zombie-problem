using UnityEngine;
using DG.Tweening;
public class MenuSlide : MonoBehaviour
{
    public float transitionDuration = 0.5f;

    private Vector2 hiddenPosition;
    private RectTransform menu;
    private Vector2 shownPosition = Vector2.zero; // Middle of screen

    private void Awake()
    {
        menu = GetComponent<RectTransform>();
        hiddenPosition = new Vector2(0, -Screen.height); // Off-screen below
        menu.anchoredPosition = hiddenPosition;
    }

    public void ShowPauseMenu()
    {
        menu.DOAnchorPos(shownPosition, transitionDuration)
            .SetEase(Ease.OutExpo).SetUpdate(true);
        Time.timeScale = 0f;
    }

    public void HidePauseMenu()
    {
        menu.DOAnchorPos(hiddenPosition, transitionDuration)
            .SetEase(Ease.InExpo).SetUpdate(true)
            .OnComplete(() => gameObject.SetActive(false));
        Time.timeScale = 1f;
    }

}
