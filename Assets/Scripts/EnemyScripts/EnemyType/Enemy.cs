using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyType
{
    Grounder,
    Flyer,
    LongRange
};

public abstract class Enemy : MonoBehaviour, IDamagable, IAttackable
{ 
    public event Action OnDamage;
    public delegate void OnDeath();
    protected event OnDeath OnDeathAddition;
    public static event OnDeath OnCoinSpawn;
    [SerializeField] protected int maxHealth;
    [SerializeField] protected int damage;
    [SerializeField] protected float speed;
    [SerializeField] protected float attackCoolDown;
    protected int currHealth;
    protected Animator animator;
    protected Rigidbody2D rb;
    protected bool isAttacking, isDead;

    private void Awake()
    {
        currHealth = maxHealth;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        
    }

    protected IEnumerator ContinueAttack (HealthBar bar)
    {
        isAttacking = true;
        while (isAttacking)
        {
            Attack(bar);
            yield return new WaitForSeconds(attackCoolDown);
        }
    }
    public void GetDamage(int damage)
    {
        currHealth -= damage;
        OnDamage?.Invoke();
        if (currHealth <= 0)
        {
            isDead = true;
            Death();
        }
    }

    protected void Death ()
    {
        StartCoroutine(Die());
        OnCoinSpawn?.Invoke();
    }
    public abstract void Initiate();
    
  
    private void Restore()
    {
        currHealth = maxHealth;
        isAttacking = false;
        isDead = false;
        GetComponent<Collider2D>().enabled = true;
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
    }

    private IEnumerator Die()
    {
        GetComponent<Collider2D>().enabled = false;
        animator.SetBool("isDead", isDead);
        rb.velocity = Vector2.zero;
        yield return new WaitForSeconds(1f);
        OnDeathAddition?.Invoke();
        Restore();
        gameObject.SetActive(false);
    }

    public void Attack(HealthBar barrier)
    {
        barrier.ChangeHealthValue(-damage);
        animator.SetBool("isAttacking", isAttacking);
    }
}
