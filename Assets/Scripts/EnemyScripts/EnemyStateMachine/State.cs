using System;
using UnityEngine;
public interface IAnimator
{
    void SmoothTranslateAnimation(int animationTriggerName, float translateDuration);
}
public abstract class State : IState, IAnimator
{
    protected Animator _animator;
    protected int _animationIndex;
    protected Enemy _enemy;
    protected State(Animator animator, int animationIndex, Enemy enemy)
    {
        _animator = animator;
        _animationIndex = animationIndex;
        _enemy = enemy;
    }
    public abstract void Enter();
    public abstract void Exit();
    public abstract void Tick();

    public void SmoothTranslateAnimation(int animationTriggerName, float translateDuration = 0.1f)
    {
        _animator.CrossFade(animationTriggerName, translateDuration);
    }

    public void PlayAnimation(int animationTriggerName)
    {
        _animator.Play(animationTriggerName, 0, 0f);
    }
}
