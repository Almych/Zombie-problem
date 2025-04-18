

public class Ram : MeleeEnemy
{
    public override void SetStateMachine()
    {
        SetAbilities();
        runState = new RunState(animator, runAnimation, this);
        attackState = new AttackState(animator, dieAnimation);
        dieState = new DieState(animator, dieAnimation);
        stateMachine = new StateMachine(runState, attackState, dieState);
    }
    public override void Init()
    {
        base.Init();
        attackDealer = new NoneAttack(animator);
        movable = new ZigZagMove(transform, rb, meleeEnemyConfig.speed, 100, 0.5f, 10f);
        SetStateMachine();
    }

}
