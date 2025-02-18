using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public interface IEnemy
{
    void Activate();
    void Attack();

    void Move();

}
public abstract class Entity : MonoBehaviour, IEnemy
{
    public event Action<Vector3> onDeathBonus;
    [SerializeField] protected EnemyConfig enemyData;
    protected float currHealth;
    protected Animator animator;
    protected Rigidbody2D rb;
    protected Collider2D collider2D;
    protected StateMachine stateMachine;
    protected Action onDeath, onAttack, onDamage;
    public void GetDamage(Damage damage)
    {
        
    }
    public abstract void Move();
    
   
    protected void Initiate()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        collider2D = GetComponent<Collider2D>();
        currHealth = enemyData.maxHealth;
    }

    public abstract void Activate();

    public abstract void Attack();
    

    private void OnEnable()
    {
       
    }

    private void OnDisable()
    {
        
    }

    
}
