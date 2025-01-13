using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public abstract class State 
{
    protected Entity _entity;
    protected Animator animator;
    protected State(Entity entity)
    {
        _entity = entity;
        animator = entity.animator;
    }
    public abstract void Enter();
    public abstract void Exit();

    protected void ChangeAnimation(string animationName, bool animationType)
    {
        animator.SetBool(animationName, animationType);
    }
}

public class RunState : State
{
    private Transform tr;
    private Rigidbody2D rb;
    private float speed;
    public RunState(Entity entity) : base(entity)
    {
        tr = _entity.transform;
        rb = _entity.rb;
        speed = _entity.enemyData.speed;
    }

    public override void Enter()
    {
       rb.velocity = -tr.right * speed;
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
        _entity.Attack();
        ChangeAnimation("isAttacking", true);
    }

    public override void Exit()
    {
        ChangeAnimation("isAttacking", false);
    }

}

public class StunedState : State
{
    public StunedState(Entity entity) : base(entity)
    {
    }

    public override void Enter()
    {
        _entity.StopMove();
        ChangeAnimation("isStuned", true);
    }

    public override void Exit()
    {
        ChangeAnimation("isStuned", false);
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
        _entity.StartCoroutine(_entity.Die());
    }

    public override void Exit()
    {
        ChangeAnimation("isDead", false);
        _entity.Restore();
    }

  



}

