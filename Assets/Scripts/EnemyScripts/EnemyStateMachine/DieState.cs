using UnityEngine;

public class DieState : State
{
    public DieState(Animator animator, int animIndex, Enemy enemy) : base(animator, animIndex, enemy)
    {
    }

    public override void Enter()
    {
        SmoothTranslateAnimation(_animationIndex);
        _enemy.CallDeathAbility();
    }

    public override void Exit()
    {
    }

    public override void Tick()
    {
        
    }
}
