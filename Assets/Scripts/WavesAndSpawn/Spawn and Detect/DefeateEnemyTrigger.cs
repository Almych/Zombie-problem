using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefeatedEnemyTrigger : MonoBehaviour
{
    private HashSet<Entity> activeEnemies = new HashSet<Entity>();
    private bool isPaused = false;
    private const int maxCheckTicks = 60; 
    private int currTicks = 0;
    private bool wavesEnded;

    private void Awake()
    {
        UpdateSystem.OnLateUpdate += Tick;
        EventBus.Subscribe<OnPauseEvent>(OnPause, 1);
        EventBus.Subscribe<OnWavesEnd>(OnWavesEnd);
    }

    private void OnDestroy()
    {
        UpdateSystem.OnLateUpdate -= Tick;
        EventBus.UnSubscribe<OnWavesEnd>(OnWavesEnd);
        EventBus.UnSubscribe<OnPauseEvent>(OnPause);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Entity enemy = collision.GetComponent<Entity>();
        if (enemy != null)
        {
            activeEnemies.Add(enemy);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Entity enemy = collision.GetComponent<Entity>();
        if (enemy != null)
        {
            activeEnemies.Remove(enemy);
        }
    }

    private void Tick()
    {
        if (isPaused) return;

        if (activeEnemies.Count == 0)
        {
            if (!wavesEnded)
            EventBus.Publish(new NoEnemiesEvent());
            else 
                EventBus.Publish(new OnWinEvent());
        }
        
    }

    private void OnPause(OnPauseEvent e)
    {
        isPaused = e.IsPaused;
    }

    private void OnWavesEnd(OnWavesEnd e)
    {
        wavesEnded = true;
    }
}
