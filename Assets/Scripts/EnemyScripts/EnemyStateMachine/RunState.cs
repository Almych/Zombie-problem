using UnityEngine;

public class RunState : State
{
    public RunState(Animator animator, int animIndex, Enemy enemy) : base(animator, animIndex, enemy)
    {
    }

    public override PriorityType PriorityType => PriorityType.Low;

    public override void Enter()
    {
        SmoothTranslateAnimation(_animationIndex);
    }

    public override void Exit()
    {
        _enemy.movable.StopMove();
    }


    public override void OnTick()
    {
        AnimatorStateInfo stateInfo = _animator.GetCurrentAnimatorStateInfo(0);
        if (stateInfo.IsName("Walk") && stateInfo.normalizedTime >= 1f)
        {
            PlayAnimation(_animationIndex);
        }
        _enemy.movable.Move();
        _enemy.CallMoveAbility();
    }
}
