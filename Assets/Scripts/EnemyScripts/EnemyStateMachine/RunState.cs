using UnityEngine;

public class RunState : State
{
    private Enemy enemy;
    private int currTicks;

    public RunState( Animator animator, int animIndex, Enemy enemy) : base(animator, animIndex)
    {
        this.enemy = enemy;
    }
    public override void Enter()
    {
        SetTriggerAnimation(_animationIndex);
    }

    public override void Exit()
    {
        enemy.movable?.StopMove();
        enemy.movable.ResetSpeed();
    }

    public override void Tick()
    {
        enemy.movable.Move();

        if (currTicks < enemy.movable.coolDownTicks)
        {
            currTicks++;
        }
        else
        {
            enemy.CallMoveAbility();
            currTicks = 0;
        }
    }
}
