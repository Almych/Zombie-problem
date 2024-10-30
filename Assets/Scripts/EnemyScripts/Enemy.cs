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
public abstract class Enemy : MonoBehaviour
{ 
    public event Action OnDeathAdditon; 
    [SerializeField] protected int maxHealth;
    [SerializeField] protected int damage;
    [SerializeField] protected int speed;
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

    protected IEnumerator Attack (HealthBar bar)
    {
        isAttacking = true;
        while (isAttacking)
        {
            bar.ChangeHealthValue(-damage);
            animator.SetBool("isAttacking", isAttacking);
            yield return new WaitForSeconds(attackCoolDown);
        }
    }
    protected void GetDamage(int damage)
    {
        currHealth -= damage;

        if (currHealth <= 0)
        {
            isDead = true;
           Death();
        }
    }

    private void Death ()
    {
        OnDeathAdditon?.Invoke();
        StartCoroutine(Die());
    }
    public void Move()
    {
        rb.velocity = -transform.right * speed;
        Restore();
    }
    protected void Restore()
    {
        currHealth = maxHealth;
        isAttacking = false;
        isDead = false;
        GetComponent<Collider2D>().enabled = true;
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        isAttacking = false;
        isDead = false;
    }

    private IEnumerator Die()
    {
        GetComponent<Collider2D>().enabled = false;
        animator.SetBool("isDead", isDead);
        rb.velocity = Vector2.zero;
        yield return new WaitForSeconds(1f);
        gameObject.SetActive(false);
    }
}
