

public class Ram : MeleeEnemy
{
    public override void SetStateMachine()
    {
        runState = new RunState(animator, runAnimation, this);
        attackState = new AttackState(animator, dieAnimation);
        dieState = new DieState(animator, dieAnimation);
        stateMachine = new StateMachine(runState, attackState, dieState);
    }
    public override void Init()
    {
        base.Init();
        deathAbility = GetComponent<IDeathAbility>();
        moveAbility = GetComponent<IMoveAbility>();
        attackDealer = new NoneAttack();
        movable = new ZigZagMove(transform, rb, meleeEnemyConfig.speed, moveAbility, 100, 0.5f, 10f);
        SetStateMachine();
    }

}
