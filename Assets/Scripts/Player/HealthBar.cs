using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    private const float maxHealth = 100f;
    private float currHealth;
    public float CurrHealth {
        get => currHealth;
        private set
        {
            currHealth = Mathf.Clamp(value, 0, maxHealth);
            EventBus.Publish(new HealthChangeEvent(currHealth));
        }
    
    }

    void Awake()
    {
        Init();
    }

    private void Init()
    {
        CurrHealth = maxHealth;
    }

    


    public void ChangeHealthValue(float value)
    {
        CurrHealth += value;
        if (CurrHealth <= 0f)
        {
            EventBus.Publish(new PlayerDieEvent());
        }
    }
}
