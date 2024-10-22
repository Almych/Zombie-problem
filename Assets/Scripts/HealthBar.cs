using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public static HealthBar Instance;
    public EventHandler<float> OnHealthChanged;
    private const float maxHealth = 10f;
    private float currHealth;
    public float CurrHealth {
        get => currHealth;
        private set
        {
            currHealth = Mathf.Clamp(value, 0, maxHealth);
            OnHealthChanged?.Invoke(this, currHealth);
        }
    
    }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    private void Start()
    {
        currHealth = maxHealth;
        ChangeHealthValue(maxHealth);
    }


    public float ChangeHealthValue(float value)
    {
        if (CurrHealth <= 0f)
        {
            Debug.Log("dead");
            return 0;
        }else
        {
            CurrHealth += value / maxHealth;
            return CurrHealth;
        }
        
    }
}
