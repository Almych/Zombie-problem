

public class Ram : MeleeEnemy
{
    public override void SetStateMachine()
    {
        SetAbilities();
        idleState = new IdleState(animator, idleAnimation, this, () => stateMachine?.SwitchState(stateMachine.lastState));
        runState = new RunState(animator, runAnimation, this);
        attackState = new AttackState(animator, dieAnimation, this);
        dieState = new DieState(animator, dieAnimation, this, deathProvider);
        stateMachine = new StateMachine(idleState, runState, attackState, dieState);
    }
}
