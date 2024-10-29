using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
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
    private bool isAttacking, isDead;
    private Animator anim;
    private float currhealth;
    private const float attackCoolDown = 2f;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        Move();
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
    public void Move()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = -transform.right * speed;
        currhealth = health;
        GetComponent<Collider2D>().enabled = true;
        isAttacking = false;
        isDead = false;
    }
    
    public void GetDamage(float damage)
    {
        if (currhealth <= 0)
        {
            isDead = true;
            StartCoroutine(OnDeath());
            CoinCall.Invoke(transform.position);
        }else
        {
            StartCoroutine(MoveDiagonal());
            currhealth -= damage;
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
            anim.SetBool("isAttacking", isAttacking);
            yield return new WaitForSeconds(attackCoolDown);
        }
    }

    private IEnumerator MoveDiagonal()
    {
            var moveDia = UnityEngine.Random.Range(0, 3);
            if (moveDia == 1)
            {
                rb.velocity = transform.up + -transform.right * speed;
            }
            else if (moveDia == 2)
            {
                rb.velocity = -transform.up + -transform.right * speed;
            }
            yield return new WaitForSeconds(1.5f);
            rb.velocity = -transform.right * speed;
    }
    
    private IEnumerator OnDeath()
    {
        GetComponent<Collider2D>().enabled = false;
        anim.SetBool("isDead", isDead);
        rb.velocity = Vector2.zero;
        yield return new WaitForSeconds(1f);
        gameObject.SetActive(false);
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
    }
}
