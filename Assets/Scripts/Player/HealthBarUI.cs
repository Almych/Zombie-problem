using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    private Image healthBar;

    private void Awake()
    {
        healthBar = GetComponent<Image>();
        EventBus.Subscribe<HealthChangeEvent>(HealthBarUpdate);
    }

    private void OnDestroy()
    {
        EventBus.UnSubscribe<HealthChangeEvent>(HealthBarUpdate);
    }

    private void HealthBarUpdate(HealthChangeEvent e)
    {
        healthBar.fillAmount = e.value;
    }
}
