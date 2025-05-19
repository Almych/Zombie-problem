

using UnityEngine;

public class Mage : RangeEnemy
{
    [SerializeField] private int switchTime;
    private RunAttackState RunAttackState;
    public override void SetStateMachine()
    {
        SetAbilities();
        idleState = new IdleState(animator, idleAnimation, this, () => stateMachine?.SwitchState(stateMachine.lastState));
        runState = new RunState(animator, runAnimation, this);
        attackState = new AttackState(animator, attackAnimation, this);
        dieState = new DieState(animator, dieAnimation, this, deathProvider);
        RunAttackState = new RunAttackState(runState, attackState, switchTime, this);
        stateMachine = new StateMachine(idleState, runState, attackState, dieState);
    }
    public override void InitiateMachine()
    {
        stateMachine?.SwitchState(RunAttackState);
    }
}
