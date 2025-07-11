using UnityEngine;

public class AttackState : State
{
    private int currentTicks;

    public AttackState(Animator animator, int animIndex, Enemy enemy) : base(animator, animIndex, enemy)
    {

    }

    public override PriorityType PriorityType => PriorityType.Low;

    public override void Enter()
    {
        SmoothTranslateAnimation(_animationIndex);
        currentTicks = 0;
    }

    public override void Exit()
    {
        StopAnimation();
    }

    public override void OnTick()
    {
        currentTicks++;
        if (currentTicks >= _enemy.attackDealer.coolDownTIcks)
        {
            _enemy.CallAttackAbility();
            PlayAnimation(_animationIndex);
            currentTicks = 0;
        }
    }
}
