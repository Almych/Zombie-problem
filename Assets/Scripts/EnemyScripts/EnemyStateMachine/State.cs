using System;
using UnityEngine;
public interface IAnimator
{
    void SmoothTranslateAnimation(int animationTriggerName, float translateDuration);
}

public enum PriorityType
{
    Low,
    Medium, 
    High
}
public abstract class State : IState, IAnimator
{
    protected Animator _animator;
    protected int _animationIndex;
    protected Enemy _enemy;

    private bool _isFrozen;
    private int _freezeTimer;
    private int _freezeDuration;
    public abstract PriorityType PriorityType { get; }
    protected State(Animator animator, int animationIndex, Enemy enemy)
    {
        _animator = animator;
        _animationIndex = animationIndex;
        _enemy = enemy;
    }
    public abstract void Enter();
    public abstract void Exit();
    public virtual void Tick()
    {
        if (_isFrozen)
        {
            _freezeTimer++;
            if (_freezeTimer >= _freezeDuration)
            {
                Unfreeze();
            }
            return;
        }
        OnTick();
    }
    public abstract void OnTick();
    public virtual void Stop()
    {
        _animator.speed = 0;
    }

    public void SmoothTranslateAnimation(int animationTriggerName, float translateDuration = 0.1f)
    {
        _animator.CrossFade(animationTriggerName, translateDuration);
    }

    public void StopAnimation() => _animator.StopPlayback();

    public void PlayAnimation(int animationTriggerName)
    {
        _animator.Play(animationTriggerName, 0, 0f);
    }
    public bool isFroze()
    {
        return _isFrozen;
    }

    public virtual void Freeze(int duration)
    {
        if (_isFrozen)
        {
            _freezeDuration += duration; 
            return;
        }

        _isFrozen = true;
        _freezeTimer = 0;
        _freezeDuration = duration;
        _animator.speed = 0;
        Exit();
    }

    private void Unfreeze()
    {
        _isFrozen = false;
        _animator.speed = 1;
        Enter();
    }
}
