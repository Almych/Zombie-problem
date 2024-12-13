using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entity : MonoBehaviour
{
   [SerializeField] protected int maxHealth;
    public event Action OnDamage;
    public delegate void OnDeath(Vector3 position);
    protected event Action OnDeathAddition;
    public static event OnDeath OnCoinSpawn;
    protected float currHealth;
    protected Animator animator;
    protected Rigidbody2D rb;
    protected bool isAttacking, isDead;
    protected SpriteRenderer spriteColor;
    protected Collider enemyCollider;

    public abstract void Initiate();

    public void GetDamage(float damage)
    {
        currHealth -= damage;
        OnDamage?.Invoke();
        if (currHealth <= 0)
        {
            isDead = true;
            Death();
        }
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        spriteColor = GetComponent<SpriteRenderer>();
        enemyCollider = GetComponent<Collider>();
    }
    protected void Death()
    {
        StartCoroutine(Die());
        OnCoinSpawn?.Invoke(transform.position);
    }
    protected void Restore()
    {
        currHealth = maxHealth;
        isAttacking = false;
        isDead = false;
        enemyCollider.enabled = true;
        spriteColor.color = Color.white;
    }

    private IEnumerator Die()
    {
        enemyCollider.enabled = false;
        animator.SetBool("isDead", isDead);
        rb.velocity = Vector2.zero;
        yield return new WaitForSeconds(1f);
        OnDeathAddition?.Invoke();
        Restore();
        gameObject.SetActive(false);
    }
}
