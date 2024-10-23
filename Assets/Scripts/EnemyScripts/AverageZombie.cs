using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class AverageZombie : MonoBehaviour
{
    public enum ZombieType
    {
        Average,
        Long,
        Speedy,
        Big
    };
    public ZombieType type;
    public delegate void OnCoinSpawn(Vector3 position);
    public static OnCoinSpawn CoinCall;
    [SerializeField] private float damage, speed, health;
    private Rigidbody2D rb;
    private bool isAttacking;
    private float currhealth;
    private const float attackCoolDown = 2f;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currhealth = health;
        isAttacking = false;
        rb.velocity = -transform.right * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.GetComponent<HealthBar>() != null && !isAttacking)
        {
            var barrier = collision.collider.GetComponent<HealthBar>();
            isAttacking = true;
            StartCoroutine(Attack(barrier));
        } 
    }

    public void GetDamage( float damage)
    {
        currhealth -= damage;
        if (currhealth <= 0)
        {
            CoinCall.Invoke(transform.position);
            gameObject.SetActive(false);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.GetComponent<HealthBar>() != null && !isAttacking)
        {
            isAttacking = false;
        }
    }

    private IEnumerator Attack(HealthBar healthBar)
    {
        while (isAttacking)
        {
            healthBar.ChangeHealthValue(-damage);
            yield return new WaitForSeconds(attackCoolDown);
        }
    }
}
