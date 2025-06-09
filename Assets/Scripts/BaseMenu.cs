using DG.Tweening;
using UnityEngine;

public abstract class BaseMenu : MonoBehaviour
{
    public float transitionDuration = 0.5f;
    protected Vector2 hiddenPosition;
    protected RectTransform menu;
    protected Vector2 shownPosition = Vector2.zero;

    protected void Awake()
    {
        menu = GetComponent<RectTransform>();
        hiddenPosition = new Vector2(0, -Screen.height);
        menu.anchoredPosition = hiddenPosition;
    }

    public virtual void ShowMenu(int stars = 0, float timeSpent = 0, int damageTaken = 0)
    {
        gameObject.SetActive(true);
        menu.DOAnchorPos(shownPosition, transitionDuration)
            .SetEase(Ease.OutExpo).SetUpdate(true);
        Time.timeScale = 0f;
    }

    public virtual void HidePauseMenu()
    {
        menu.DOAnchorPos(hiddenPosition, transitionDuration)
            .SetEase(Ease.InExpo).SetUpdate(true)
            .OnComplete(() => gameObject.SetActive(false));
        Time.timeScale = 1f;
    }
}
