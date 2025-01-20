using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefeatedEnemyTrigger : MonoBehaviour
{
    public static DefeatedEnemyTrigger Instance;
    public event Action GetActiveEnemies;
    private List<Entity> activeEnemies = new List<Entity>();
    private bool hasEnemy = false;
    private bool isEnd = false;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void Initiate()
    {
        GetActiveEnemies?.Invoke();
        StartCoroutine(CheckActiveEnemies());
    }

    public void StopCheckForEnemies()
    {
        isEnd = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Entity>() != null)
        {
            activeEnemies.Add(collision.GetComponent<Entity>());
            hasEnemy = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Entity>() != null)
        {
            activeEnemies.Remove(collision.GetComponent<Entity>());

            if(activeEnemies.Count <= 0)
            {
                hasEnemy = false;
            }
            
        }
    }

    private IEnumerator CheckActiveEnemies()
    {
        while (!isEnd)
        {
            yield return new WaitForSeconds(2f);
            if (!hasEnemy)
            GetActiveEnemies?.Invoke();
        }
    }

}
