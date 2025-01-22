using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;


public abstract class State 
{
    protected Transform _transform;
    protected Rigidbody2D _rb;
    protected Animator _animator;
    protected State(Animator animator, Rigidbody2D rb, Transform transform)
    {
        _transform = transform;
        _animator = animator;
        _rb = rb;
    }
    public abstract void Enter();
    public abstract void Exit();

    protected void ChangeAnimation(string animationName, bool animationType)
    {
        _animator.SetBool(animationName, animationType);
    }
}

public class RunState : State
{
    private float speed;

    public RunState(Animator animator, Rigidbody2D rb, Transform transform, float moveSpeed) : base(animator, rb, transform)
    {
        speed = moveSpeed;
    }

    public override void Enter()
    {
       _rb.velocity = -_transform.right * speed;
        ChangeAnimation("isRunning", true);
    }

    public override void Exit()
    {
        ChangeAnimation("isRunning", false);
    }
}

public class AttackState : State
{
    private Action Attack;
    public AttackState(Animator animator, Rigidbody2D rb, Transform transform, Action UniqAttack) : base(animator, rb, transform)
    {
        Attack = UniqAttack;
    }

    public override void Enter()
    {
        Attack?.Invoke();
        ChangeAnimation("isAttacking", true);
    }

    public override void Exit()
    {
        ChangeAnimation("isAttacking", false);
    }

}

public class StunedState : State
{
    private Action _Stuned;
    public StunedState(Animator animator, Rigidbody2D rb, Transform transform) : base(animator, rb, transform)
    {
    }

    public override void Enter()
    {
        ChangeAnimation("isStuned", true);
    }

    public override void Exit()
    {
        ChangeAnimation("isStuned", false);
    }

   
}


public class DeadState : State
{
    private Action _Restore;
    private IEnumerator _Die;
    private MonoBehaviour _mono;
    public DeadState(Animator animator, Rigidbody2D rb, Transform transform, Action Restore, IEnumerator Die, MonoBehaviour mono) : base(animator, rb, transform)
    {
        _Restore = Restore;
        _Die = Die;
        _mono = mono;
    }

    public override void Enter()
    {
        ChangeAnimation("isDead", true);
        _mono.StartCoroutine(_Die);
    }

    public override void Exit()
    {
        ChangeAnimation("isDead", false);
        _Restore?.Invoke();
    }

  



}

