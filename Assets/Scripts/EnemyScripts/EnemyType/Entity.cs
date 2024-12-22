using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    [SerializeField] protected EnemyConfig enemyData;
    protected  Action OnDamage;
    public delegate void OnDeathAdittion(Vector3 position);
    protected Action OnDeath;
    public static event OnDeathAdittion OnCoinSpawn;
    protected float currHealth;
    protected Animator animator;
    protected Rigidbody2D rb;
    protected bool isAttacking, isDead;
    protected SpriteRenderer spriteColor;
    protected Collider2D enemyCollider;
    protected EnemyAbillity enemyAbility;
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

    public abstract void AbilityAdd();

    protected void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        spriteColor = GetComponent<SpriteRenderer>();
        enemyCollider = GetComponent<Collider2D>();
        AbilityAdd();
        currHealth = enemyData.maxHealth;
    }
    protected void Death()
    {
        StartCoroutine(Die());
        OnCoinSpawn?.Invoke(transform.position);
    }
    private void Restore()
    {
        currHealth = enemyData.maxHealth;
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
        OnDeath?.Invoke();
        Restore();
        gameObject.SetActive(false);
    }


}
