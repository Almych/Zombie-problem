
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class LoadBar : MonoBehaviour
{
    private Image barProgress;
    [SerializeField]private float duration = 0.5f;
    private float value;

    void Awake()
    {
        barProgress = GetComponent<Image>();
        EventBus.Subscribe<OnLoadEvent>(ChangeProgressBar);
    }

    void OnDestroy()
    {
        EventBus.UnSubscribe<OnLoadEvent>(ChangeProgressBar);
    }

    public void ChangeProgressBar(OnLoadEvent e)
    {
        value += 0.1f;
        barProgress.DOFillAmount(Mathf.Clamp01(value), duration);
    }
}
