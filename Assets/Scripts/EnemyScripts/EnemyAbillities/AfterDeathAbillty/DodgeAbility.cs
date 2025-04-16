using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodgeAbility : MonoBehaviour, IMoveAbility
{
    [SerializeField] private int timeToDodge;
    [SerializeField] float frequency, amplitute = 1f;
    private IMoveStrategy moveStrategy;
    private Enemy enemy;
    private Rigidbody2D rb;
    private float speed;
    private bool Called;
    void Start()
    {
        Called = false;
        enemy = GetComponent<Enemy>();
        rb = GetComponent<Rigidbody2D>();
        speed = enemy.enemyConfig.speed;
    }
    public void OnMove()
    {
        if (Called)
        {
            return;
        }
        else
        {
            enemy.movable = new ZigZagMove(transform, rb, speed, this, timeToDodge, amplitute, frequency);
            Called = true;
        }
    }
}
