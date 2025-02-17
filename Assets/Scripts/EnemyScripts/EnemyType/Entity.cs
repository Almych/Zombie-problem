using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    public EnemyOnDamageAbilityConfig onDamageAbilities;
    public EnemyOnDeathAbilityConfig onDeathAbilities;
    public EnemyUniqDefense defense;
    public event Action<Vector3> onDeathBonus;
    public EnemyConfig enemyData;
    private float currHealth;
    private Animator animator;
    private Rigidbody2D rb;
    private SpriteRenderer spriteColor;
    private Collider2D enemyCollider;
    private StateMachine stateMachine;
    public void GetDamage(Damage damage)
    {
        
    }
   
    protected void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        spriteColor = GetComponent<SpriteRenderer>();
        enemyCollider = GetComponent<Collider2D>();
        currHealth = enemyData.maxHealth;
        stateMachine = new StateMachine(this);
       
    }

    public virtual void Activate()
    {
        stateMachine.SwitchState(stateMachine.runState);
    }
    

    private void OnEnable()
    {
       
    }

    private void OnDisable()
    {
        
    }

    private void OnDeathBonusTriggered(Vector3 position)
    {
        CollectablesSpawn.Instance.SpawnRandomObject(position);

        onDeathBonus -= OnDeathBonusTriggered;
    }
}
