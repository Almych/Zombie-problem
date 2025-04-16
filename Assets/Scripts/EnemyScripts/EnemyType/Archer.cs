using UnityEngine;

public class Archer : RangeEnemy
{
    [SerializeField] private ShootableEnemyConfig config;

    protected override RangeEnemyConfig rangeEnemyConfig => config;

    public override void SetStateMachine()
    {
        base.SetStateMachine();
    }
    public override void Init()
    {
        base.Init();
        deathAbility = GetComponent<IDeathAbility>();
        moveAbility = GetComponent<IMoveAbility>();
        attackDealer = new RangeAttack(animator, config.bulletConfig, shootPoint);
        movable = new MoveTowards(transform, rb, rangeEnemyConfig.speed, moveAbility, 20);
        SetStateMachine();
    }
}
