using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public interface IEnemy
{
    void Init();
    void Initiate();
    void Attack();
    void TakeDamage(Damage damage);
    void Die();
}
public abstract class Entity : MonoBehaviour, IEnemy
{
    [SerializeField] protected int maxHealth;
    [SerializeField] protected EnemyUniqDefense defense;
    protected float currHealth;
    protected Animator animator;
    protected Rigidbody2D rb;
    protected Collider2D enemyCollider;
    protected MoveProvider moveProvider;
    protected IAttackDealer attackDealer;

    protected RunState runState;
    protected DieState dieState;
    protected AttackState attackState;
    protected StateMachine stateMachine;
    public void TakeDamage(Damage damage)
    {
        currHealth -= defense.Defense(damage);
        if (currHealth <= 0)
        {
            stateMachine.SwitchState(dieState);
        }
    }

    public virtual void Init()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        enemyCollider = GetComponent<Collider2D>();
        moveProvider = GetComponent<MoveProvider>();
        runState = new RunState(animator, moveProvider);
        attackState = new AttackState(animator, this);
        dieState = new DieState(animator);
        stateMachine = new StateMachine(runState, attackState, dieState);
    }

    public void Initiate()
    {
        currHealth = maxHealth;
        stateMachine.SwitchState(runState);
    }


    public void Die()
    {
        gameObject.SetActive(false);
    }
    

    public void OnDeathAction()
    {
        CollectablesSpawn.SpawnRandomObject(transform.position);
    }

    protected virtual void OnEnable()
    {
        if(stateMachine != null) 
        TickSystem.OnTick += stateMachine.OnTick;
    }

    protected virtual void OnDisable()
    {
        if (stateMachine != null)
            TickSystem.OnTick -= stateMachine.OnTick;
    }


    public virtual void Attack()
    {
        attackDealer?.Attack();
    }
}
