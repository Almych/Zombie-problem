using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarView : MonoBehaviour
{
    [SerializeField] private Slider healthbar;


    private void OnEnable()
    {
        HealthBar.Instance.OnHealthChanged += HealthBarUpdate;
    }

    private void OnDisable()
    {
       HealthBar.Instance.OnHealthChanged -= HealthBarUpdate;
    }

    private void HealthBarUpdate(object sender, float value)
    {
        healthbar.value = value;
    }
}
