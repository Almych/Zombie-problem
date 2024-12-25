using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class State
{
    protected Entity _entity;
    protected State(Entity entity)
    {
        _entity = entity;
    }
    public abstract void Enter();
    public abstract void Exit();
}

public class RunState : State
{
    public RunState(Entity entity) : base(entity)
    {
    }

    public override void Enter()
    {
        _entity.ChangeAnimation("isRunning", true);
    }

    public override void Exit()
    {
        _entity.ChangeAnimation("isRunning", false);
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
        _entity.ChangeAnimation("isAttacking", true);
    }

    public override void Exit()
    {
        _entity.ChangeAnimation("isAttacking", false);
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
        _entity.ChangeAnimation("isStuned", true);
    }

    public override void Exit()
    {
        _entity.ChangeAnimation("isStuned", false);
    }

   
}


public class DeadState : State
{
    public DeadState(Entity entity) : base(entity)
    {
    }

    public override void Enter()
    {
        _entity.ChangeAnimation("isDead", true);
        _entity.Death();
    }

    public override void Exit()
    {
        _entity.ChangeAnimation("isDead", false);
        _entity.Restore();
    }

  



}

