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
        attackDealer = new RangeAttack(animator, config.bulletConfig, shootPoint);
        movable = new MoveTowards(transform, rb, rangeEnemyConfig.speed, 20);
        SetStateMachine();
    }
}
