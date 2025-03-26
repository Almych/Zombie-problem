using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    private Image healthBar => GetComponent<Image>();

    private void OnEnable()
    {
        EventBus.Subscribe<HealthChangeEvent>(HealthBarUpdate);
    }

    private void OnDisable()
    {
        EventBus.UnSubscribe<HealthChangeEvent>(HealthBarUpdate);
    }

    private void HealthBarUpdate(HealthChangeEvent e)
    {
        healthBar.fillAmount = e.value;
    }
}
