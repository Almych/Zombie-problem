using UnityEngine;
public interface IAnimator
{
    void SetTriggerAnimation(string animationTriggerName);
}
public abstract class State : IState, IAnimator
{
    protected Animator _animator;
    protected const string dieAnimation = "Die";
    protected const string attackAnimation = "Attack";
    protected const string runAnimation = "Walk";

    protected State(Animator animator)
    {
        _animator = animator;
    }
    public abstract void Enter();
    public abstract void Exit();
    public abstract void Tick();

    public void SetTriggerAnimation(string animationTriggerName)
    {
        _animator?.SetTrigger(animationTriggerName);
    }
}
