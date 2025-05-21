using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    private const float maxHealth = 100f;
    private float currHealth;

    public float CurrHealth
    {
        get => currHealth;
        private set
        {
            currHealth = Mathf.Clamp(value, 0f, maxHealth);
            EventBus.Publish(new HealthChangeEvent(currHealth/ maxHealth));
        }
    }

    void Awake()
    {
        Init();
        EventBus.Subscribe<OnHealEvent>(Heal);
    }

    void OnDestroy()
    {
        EventBus.UnSubscribe<OnHealEvent>(Heal);
    }

    private void Init()
    {
        currHealth = maxHealth;  
        EventBus.Publish(new HealthChangeEvent(currHealth)); 
    }

    public void ChangeHealthValue(float value)
    {
        CurrHealth += value;

        if (CurrHealth <= 0f)
        {
            EventBus.Publish(new PlayerDieEvent());
        }
    }

    public void Heal(OnHealEvent e)
    {
        CurrHealth += e.healPoints;
        Debug.Log(CurrHealth);
    }
}
