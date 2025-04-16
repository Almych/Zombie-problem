

public class Knight : MeleeEnemy
{
    public override void SetStateMachine()
    {
        base.SetStateMachine();
    }
    public override void Init()
    {
        base.Init();
        deathAbility = GetComponent<IDeathAbility>();
        moveAbility = GetComponent<IMoveAbility>();
        attackDealer = new MeleeAttack(animator, meleeEnemyConfig.damage);
        movable = new MoveTowards(transform, rb, meleeEnemyConfig.speed, moveAbility, 20);
        SetStateMachine();
    }
}
