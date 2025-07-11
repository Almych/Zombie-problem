using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefeatedEnemyTrigger : MonoBehaviour
{
    private HashSet<Enemy> activeEnemies = new HashSet<Enemy>();
    private bool isPaused = false;
    private const int maxCheckTicks = 60; 
    private int currTicks = 0;
    private bool wavesEnded;
    private const float winShowSeconds = 5f;
    private void Awake()
    {
        UpdateSystem.OnLateUpdate += Tick;
        EventBus.Subscribe<EffectEnemiesEvent>(EffectEnemies, 1);
        EventBus.Subscribe<OnPauseEvent>(OnPause, 1);
        EventBus.Subscribe<OnWavesEnd>(OnWavesEnd);
    }

    private void OnDestroy()
    {
        UpdateSystem.OnLateUpdate -= Tick;
        EventBus.UnSubscribe<EffectEnemiesEvent>(EffectEnemies);
        EventBus.UnSubscribe<OnWavesEnd>(OnWavesEnd);
        EventBus.UnSubscribe<OnPauseEvent>(OnPause);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var enemy = collision.GetComponent<Enemy>();
        if (enemy != null)
        {
            activeEnemies.Add(enemy);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        var enemy = collision.GetComponent<Enemy>();
        if (enemy != null)
        {
            activeEnemies.Remove(enemy);
        }
    }

    private void EffectEnemies(EffectEnemiesEvent e)
    {
        foreach (Enemy enemy in activeEnemies)
        {
           e.applyDamage?.MakeDamage(enemy);
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
                StartCoroutine(ShowWinLevel());
        }
        
    }
    private IEnumerator ShowWinLevel()
    {
        yield return new WaitForSeconds(winShowSeconds);
        EventBus.Publish(new OnWinEvent());
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
