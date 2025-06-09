using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class HoverButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private float hoverScale = 1.1f;
    [SerializeField] private float duration = 0.2f;

    private Vector3 originalScale;
    private Tween currentTween;

    void Awake()
    {
        originalScale = transform.localScale;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (currentTween != null && currentTween.IsActive()) currentTween.Kill();

        currentTween = transform.DOScale(originalScale * hoverScale, duration)
                               .SetEase(Ease.OutQuad);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (currentTween != null && currentTween.IsActive()) currentTween.Kill();

        currentTween = transform.DOScale(originalScale, duration)
                               .SetEase(Ease.OutQuad);
    }
}
