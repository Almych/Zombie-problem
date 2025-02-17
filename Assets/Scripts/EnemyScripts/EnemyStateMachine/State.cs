using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;


public abstract class State 
{
    protected Entity _enemy;
    protected State(Entity entity)
    {
        _enemy = entity;
    }
    public abstract void Enter();
    public abstract void Exit();

    protected void ChangeAnimation(string animationName, bool animationType)
    {
        //_enemy.animator.SetBool(animationName, animationType);
    }

    protected void StopMove()
    {
       // _enemy.rb.velocity = Vector3.zero;
    }

}

public class RunState : State
{

    public RunState(Entity entity) : base(entity)
    {
    }

    public override void Enter()
    {
       //_enemy.rb.velocity = -_enemy.transform.right * _enemy.enemyData.speed;
        ChangeAnimation("isRunning", true);
    }

    public override void Exit()
    {
        ChangeAnimation("isRunning", false);
    }
}

public class AttackState : State
{

    public AttackState(Entity entity) : base(entity)
    {
    }

    public override void Enter()
    {
       // _enemy.Attack();
        ChangeAnimation("isAttacking", true);
    }

    public override void Exit()
    {
        ChangeAnimation("isAttacking", false);
    }

}

public class StunnedState : State
{

    public StunnedState(Entity entity) : base(entity)
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
    public DeadState(Entity entity) : base(entity)
    {
    }

    public override void Enter()
    {
        ChangeAnimation("isDead", true);
        _enemy.StartCoroutine(Die());
    }

    public override void Exit()
    {
        ChangeAnimation("isDead", false);
        Restore();
    }


    private IEnumerator Die()
    {
        StopMove();
        //_enemy.enemyCollider.enabled = false;
        yield return new WaitForSeconds(1f);
       // _enemy.OnDeath?.Invoke();
        _enemy.gameObject.SetActive(false);
    }

    private void Restore()
    {
       // _enemy.currHealth = _enemy.enemyData.maxHealth;
       // _enemy.enemyCollider.enabled = true;
    }

}

