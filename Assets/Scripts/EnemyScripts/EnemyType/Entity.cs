using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public interface IEnemy
{
    void Initiate();

    void Stun();
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
    protected RunState runState;
    protected DieState dieState;
    private event Action onDeath;
    protected IDeathAbility deathAbility => GetComponent<IDeathAbility>();
    public void TakeDamage(Damage damage)
    {
        currHealth -= damage.GetDamage();
        if (currHealth <= 0)
        {
            stateMachine.SwitchState<DieState>();
        }
    }

    public virtual void Init()
    {
        gameObject.SetActive(true);
        stateMachine = new StateMachine();
        runState = new RunState(transform, rb, animator, moveWay);
        dieState = new DieState(transform, rb, animator, this);
        stateMachine.AddState(dieState);
        stateMachine.AddState(runState);
        gameObject.SetActive(false);
    }



    public virtual void Initiate()
    {
        currHealth = maxHealth;
        stateMachine.SwitchState<RunState>();
    }

    public virtual void Die()
    {
        enemyCollider.enabled = false;
        moveWay?.StopMove();
        enemyCollider.enabled = true;
        deathAbility?.onDeath();
        onDeath.Invoke();
        gameObject.SetActive(false);
    }

    public void Stun()
    {
        stateMachine?.SwitchState<StunState>();
    }

    protected void OnEnable()
    {
        onDeath += OnDeathAction;
    }

    protected void OnDisable()
    {
        onDeath -= OnDeathAction;
    }

    public void OnDeathAction()
    {
        CollectablesSpawn.SpawnRandomObject(transform.position);
    }
}
