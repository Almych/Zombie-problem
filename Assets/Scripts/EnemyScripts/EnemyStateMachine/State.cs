using System;
using UnityEngine;
public interface IAnimator
{
    void SetTriggerAnimation(int animationTriggerName);
}
public abstract class State : IState, IAnimator
{
    protected Animator _animator;
    protected int _animationIndex;
    protected Action<State> requestChangeState;
    protected State(Animator animator, int animationIndex)
    {
        _animator = animator;
        _animationIndex = animationIndex;
    }
    public abstract void Enter();
    public abstract void Exit();
    public abstract void Tick();

    public void SetTriggerAnimation(int animationTriggerName)
    {
        _animator.CrossFade(animationTriggerName, 0f);
    }
}
