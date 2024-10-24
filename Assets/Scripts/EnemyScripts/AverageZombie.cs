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
        isAttacking = false;
        Move(GetComponent<Rigidbody2D>());
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
    public void Move(Rigidbody2D rb)
    {
        rb.velocity = -transform.right * speed;
        currhealth = health;
    }
    
    public void GetDamage( float damage)
    {
        StartCoroutine(MoveDiagonal(GetComponent<Rigidbody2D>()));
        currhealth -= damage;
        if (currhealth <= 0)
        {
            CoinCall.Invoke(transform.position);
            gameObject.GetComponent<SpriteRenderer>().color = Color.white;
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

    private IEnumerator MoveDiagonal(Rigidbody2D rb)
    {
        var moveDia = UnityEngine.Random.Range(0, 2);
        if (moveDia > 0)
        {
            rb.velocity = transform.up + -transform.right * speed;
        }
        yield return new WaitForSeconds(1.5f);
        rb.velocity = -transform.right * speed;
    }
}
