using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    private Slider healthBar => GetComponent<Slider>();

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
        healthBar.value = e.value;
    }
}
