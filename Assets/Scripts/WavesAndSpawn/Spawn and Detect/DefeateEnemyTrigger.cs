using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefeatedEnemyTrigger : MonoBehaviour
{
    private HashSet<Entity> activeEnemies = new HashSet<Entity>();
    private bool isCheckingForEnemies = true;
    private const float checkIntervals = 1f;
    private bool isPaused = false;

    void Start()
    {
        StartCheckingForEnemies();
    }

    public void StartCheckingForEnemies()
    {
        StartCoroutine(CheckForEnemies());
    }

    public void StopCheckingForEnemies()
    {
        isCheckingForEnemies = false;
    }

    void Awake()
    {
        EventBus.Subscribe<OnPauseEvent>(OnPause, 1);
    }

    void OnDestroy()
    {
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

    private IEnumerator CheckForEnemies()
    {
        while (isCheckingForEnemies)
        {
            if (isPaused)
                yield return null;
            if (activeEnemies.Count <= 0)
            {
                EventBus.Publish(new NoEnemiesEvent());
            }

            yield return new WaitForSeconds(checkIntervals);
        }
    }

    private void OnPause(OnPauseEvent e)
    {
        isPaused = e.IsPaused;
    }

    
}
