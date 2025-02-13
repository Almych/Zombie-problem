using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    public EnemyOnDamageAbilityConfig onDamageAbilities;
    public EnemyOnDeathAbilityConfig onDeathAbilities;
    public event Action<Vector3> onDeathBonus;
    public EnemyConfig enemyData;
    protected Action OnDamage;
    internal protected Action OnDeath;
    internal protected float currHealth;
    internal protected Animator animator;
    internal protected Rigidbody2D rb;
    internal protected SpriteRenderer spriteColor;
    internal protected Collider2D enemyCollider;
    internal protected StateMachine stateMachine;
    internal protected OnDamageEnemyAbility damageAbilities;
    internal protected OnDeathEnemyAbility deathAbilities;
    public void GetDamage(float damage, IDamage damageType)
    {
        currHealth -= damage;
        if (currHealth <= 0)
        {
            stateMachine.SwitchState(stateMachine.deadState);
            onDeathBonus?.Invoke(transform.position);
        }
        else
        {
            if (damageType == default)
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
        damageAbilities = EnemyAbilityFactory.OnDamageAbilityAdd(onDamageAbilities, this);
        deathAbilities = EnemyAbilityFactory.OnDeathAbilityAdd(onDeathAbilities, this);
        stateMachine.SwitchState(stateMachine.runState);

    }

    public virtual void Initiate()
    {
        stateMachine.SwitchState(stateMachine.runState);
    }
    

    private void OnEnable()
    {
        if (damageAbilities != null)
        OnDamage += damageAbilities.OnDamage;
        if(deathAbilities != null)
        OnDeath += deathAbilities.OnDeath;
        onDeathBonus += OnDeathBonusTriggered;
    }

    private void OnDisable()
    {
        if (damageAbilities != null)
            OnDamage -= damageAbilities.OnDamage;
        if (deathAbilities != null)
            OnDeath -= deathAbilities.OnDeath;
        onDeathBonus -= OnDeathBonusTriggered;
    }

    private void OnDeathBonusTriggered(Vector3 position)
    {
        CollectablesSpawn.Instance.SpawnRandomObject(position);

        onDeathBonus -= OnDeathBonusTriggered;
    }
}
