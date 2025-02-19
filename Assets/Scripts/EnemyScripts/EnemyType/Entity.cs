using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public interface IEnemy
{
    void Initiate();
    void Attack();

    void Move();
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
    public void GetDamage(Damage damage)
    {
        currHealth -= damage.GetDamage();
        if (currHealth <= 0 )
        {
            currHealth = 0;
        }
    }

    public abstract void Move();
    

    public abstract void Initiate();

    public abstract void Attack();
    
}
