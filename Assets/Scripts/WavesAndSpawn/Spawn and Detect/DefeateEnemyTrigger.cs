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

    void OnEnable()
    {
        EventBus.Subscribe<OnPauseEvent>(StopCheckForEnemies, 1);
        EventBus.Subscribe<OnResumeEvent>(ResumeCheckForEnemies, 1);
    }

    void OnDisable()
    {
        EventBus.UnSubscribe<OnPauseEvent>(StopCheckForEnemies);
        EventBus.UnSubscribe<OnResumeEvent>(ResumeCheckForEnemies);
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

    private void StopCheckForEnemies(OnPauseEvent e)
    {
        isPaused = true;
    }

    private void ResumeCheckForEnemies(OnResumeEvent e)
    {
        isPaused = false;
    }
}
