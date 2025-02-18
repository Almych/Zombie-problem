using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;


public abstract class State 
{
    protected Transform transform;
    protected Rigidbody2D rb;
    protected EnemyConfig enemyData;
    protected Animator animator;
    protected State(Transform transform, Rigidbody2D rb, EnemyConfig enemyConfig, Animator animator)
    {
        this.transform = transform;
        this.rb = rb;
        enemyData = enemyConfig;
        this.animator = animator;   
    }
    public abstract void Enter();
    public abstract void Exit();

    protected void ChangeAnimation(string animationName, bool animationType)
    {
        animator.SetBool(animationName, animationType);
    }

    protected void StopMove()
    {
       rb.velocity = Vector3.zero;
    }

}

public class RunState : State
{
    public RunState(Transform transform, Rigidbody2D rb, EnemyConfig enemyConfig, Animator animator) : base(transform, rb, enemyConfig, animator)
    {
    }

    public override void Enter()
    {
       rb.velocity = transform.right * enemyData.speed;
        ChangeAnimation("isRunning", true);
    }

    public override void Exit()
    {
        ChangeAnimation("isRunning", false);
    }
}

public class AttackState : State
{
    public AttackState(Transform transform, Rigidbody2D rb, EnemyConfig enemyConfig, Animator animator) : base(transform, rb, enemyConfig, animator)
    {
    }

    public override void Enter()
    {
        ChangeAnimation("isAttacking", true);
    }

    public override void Exit()
    {
        ChangeAnimation("isAttacking", false);
    }

}

public class StunnedState : State
{

    public StunnedState(Transform transform, Rigidbody2D rb, EnemyConfig enemyConfig, Animator animator) : base(transform, rb, enemyConfig, animator)
    {
    }

    public override void Enter()
    {
        ChangeAnimation("isRunning", false);
        StopMove();
    }

    public override void Exit()
    {
      //ChangeAnimation("isStunned", false);
    }

   
}


public class DeadState : State
{
    private Collider2D collider;
    public DeadState(Transform transform, Rigidbody2D rb, EnemyConfig enemyConfig, Animator animator, Collider2D collider) : base(transform, rb, enemyConfig, animator)
    {
        this.collider = collider;
    }

    public override void Enter()
    {
        ChangeAnimation("isDead", true);
    }

    public override void Exit()
    {
        ChangeAnimation("isDead", false);
        Restore();
    }


    private IEnumerator Die()
    {
        StopMove();
        collider.enabled = false;
        yield return new WaitForSeconds(1f);
       // _enemy.OnDeath?.Invoke();
       transform.gameObject.SetActive(false);
    }

    private void Restore()
    {
       // _enemy.currHealth = _enemy.enemyData.maxHealth;
       collider.enabled = true;
    }

}

