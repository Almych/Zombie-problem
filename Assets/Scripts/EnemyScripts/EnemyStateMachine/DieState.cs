using UnityEngine;

public class DieState : State
{
    private IDieStrategy _dieStrategy;
    public DieState(Animator animator, int animIndex, Enemy enemy, IDieStrategy dieStrategy) : base(animator, animIndex, enemy)
    {
        _dieStrategy = dieStrategy;
    }

    public override PriorityType PriorityType => PriorityType.High;

    public override void Enter()
    {
        SmoothTranslateAnimation(_animationIndex);
        _enemy.CallDeathAbility();
    }

    public override void Exit()
    {
        StopAnimation();
    }

    public override void Freeze(int duration)
    {
        
    }

    public override void OnTick()
    {
        
    }
}


