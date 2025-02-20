using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public interface IAnimator
{
    public void SetTriggerAnimation(string animationName, bool usage);
}
public abstract class State : IState, IAnimator
{
    public int statePriority { get; private set; }
    protected Transform _transform;
    protected Rigidbody2D _rb;
    protected Animator _animator;


    protected State(Transform transform, Rigidbody2D rb, Animator animator)
    {
        _transform = transform;
        _rb = rb;
        _animator = animator;
    }
    public abstract void Enter();
    public abstract void Exit();

    public void SetTriggerAnimation(string animationName, bool usage)
    {
        _animator.SetBool(animationName, usage);
    }

    public void SetPriority(int priority)
    {
        statePriority = priority;
    }
}
