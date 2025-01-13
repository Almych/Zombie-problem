using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    public EnemyOnDamageAbillityConfig onDamageAbillity;
    public EnemyOnDeathAbillityConfig onDeathAbillity;
    [SerializeField] internal protected EnemyConfig enemyData; 
    internal protected  Action OnDamage;
    public delegate void OnDeathAdittion(Vector3 position);
    internal protected Action OnDeath;
    public static event OnDeathAdittion OnCoinSpawn;
    internal protected float currHealth;
    internal protected Animator animator;
    internal protected Rigidbody2D rb;
    internal protected SpriteRenderer spriteColor;
    internal protected Collider2D enemyCollider;
    protected StateMachine stateMachine;
    protected OnDamageEnemyAbillity damageAbillity;
    protected OnDeathEnemyAbillity deathAbillity;
    private Action deadAction, damageAction;
    public void GetDamage(float damage, IDamage damageType)
    {
        currHealth -= damage;
        if (currHealth <= 0)
        {
            stateMachine.SwitchState(stateMachine.deadState);
        }
        else if (damageType == default)
        {
            OnDamage?.Invoke();
        }
    }
   
   

    public abstract void Attack();
    protected void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        spriteColor = GetComponent<SpriteRenderer>();
        enemyCollider = GetComponent<Collider2D>();
        currHealth = enemyData.maxHealth;
        stateMachine = new StateMachine(this);
        damageAbillity = EnemyAbillityFactory.OnDamageAbillityAdd(onDamageAbillity, this);
        deathAbillity = EnemyAbillityFactory.OnDeathAbillityAdd( onDeathAbillity, this);
        if (damageAbillity != null)
        {
            damageAction = damageAbillity.OnDamage;
        }
        if (deathAbillity != null)
        {
            deadAction = deathAbillity.OnDeath;
        }
    }

    public virtual void Initiate()
    {
        stateMachine.SwitchState(stateMachine.runState);
    }


    public void StopMove()
    {
        rb.velocity = Vector3.zero;
    }

    

    private void OnEnable()
    {
        OnDamage += damageAction;
        OnDeath += deadAction;
    }

    private void OnDisable()
    {
        OnDamage -= damageAction;
        OnDeath -= deadAction;
    }

    public void Restore()
    {
        currHealth = enemyData.maxHealth;
        enemyCollider.enabled = true;
        spriteColor.color = Color.white;
    }


    internal protected IEnumerator Die()
    {
        StopMove();
        enemyCollider.enabled = false;
        yield return new WaitForSeconds(1f);
        OnDeath?.Invoke();
        OnCoinSpawn?.Invoke(transform.position);
        gameObject.SetActive(false);
    }

}
