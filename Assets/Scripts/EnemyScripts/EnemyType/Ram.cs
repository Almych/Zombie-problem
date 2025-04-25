

public class Ram : MeleeEnemy
{
    public override void SetStateMachine()
    {
        SetAbilities();
        runState = new RunState(animator, runAnimation, this);
        attackState = new AttackState(animator, dieAnimation, this);
        dieState = new DieState(animator, dieAnimation, this);
        stateMachine = new StateMachine(runState, attackState, dieState);
    }
}
