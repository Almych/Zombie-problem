using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public interface IAnimator
{
    void SetTriggerAnimation(string animationTriggerName);
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

    public void SetPriority(int priority)
    {
        statePriority = priority;
    }

    public void SetTriggerAnimation(string animationTriggerName)
    {
        _animator?.SetTrigger(animationTriggerName);
    }
}
