

public class Ram : MeleeEnemy
{

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
