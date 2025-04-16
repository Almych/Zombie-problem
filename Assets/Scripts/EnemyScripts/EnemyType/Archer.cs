using UnityEngine;

public class Archer : RangeEnemy
{
    public override void Init()
    {
        base.Init();
        deathAbility = GetComponent<IDeathAbility>();
        moveAbility = GetComponent<IMoveAbility>();
        attackDealer = new RangeDamage(animator, rangeEnemyConfig.bulletConfig, shootPoint);
        movable = new MoveTowards(transform, rb, rangeEnemyConfig.speed, moveAbility, 20);
        SetStateMachine();
    }
}
