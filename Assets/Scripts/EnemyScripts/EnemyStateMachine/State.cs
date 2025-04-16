using UnityEngine;
public interface IAnimator
{
    void SetTriggerAnimation(int animationTriggerName);
}
public abstract class State : IState, IAnimator
{
    protected Animator _animator;
    protected int dieAnimation;
    protected int attackAnimation;
    protected int runAnimation;
    protected int idleAnimation;

    protected State(Animator animator)
    {
        dieAnimation = Animator.StringToHash("Die");
        attackAnimation = Animator.StringToHash("Attack");
        runAnimation = Animator.StringToHash("Walk");
        idleAnimation = Animator.StringToHash("Idle");
        _animator = animator;
    }
    public abstract void Enter();
    public abstract void Exit();
    public abstract void Tick();

    public void SetTriggerAnimation(int animationTriggerName)
    {
        _animator.CrossFade(animationTriggerName, 0f);
    }
}
