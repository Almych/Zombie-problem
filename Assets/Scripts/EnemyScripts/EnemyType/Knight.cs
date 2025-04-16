

public class Knight : MeleeEnemy
{
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
