using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public interface IEnemy
{
    void Initiate();

    void TakeDamage(Damage damage);
    void Die();
}
public abstract class Entity : MonoBehaviour, IEnemy
{
    [SerializeField] protected float damage;
    [SerializeField] protected float speed;
    [SerializeField] protected int maxHealth;
    protected float currHealth;
    protected Animator animator => GetComponent<Animator>();
    protected Rigidbody2D rb => GetComponent<Rigidbody2D>();
    protected Collider2D enemyCollider => GetComponent<Collider2D>();
    protected IMovable moveWay;
    protected StateMachine stateMachine;
    public void TakeDamage(Damage damage)
    {
        currHealth -= damage.GetDamage();
        if (currHealth <= 0)
        {
            stateMachine.SwitchState<DieState>();
        }
    }
    

    public virtual void Initiate()
    {
        stateMachine = new StateMachine();
    }

    public virtual void Die()
    {
        
    }
}
