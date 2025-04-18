using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mage : RangeEnemy
{
    [SerializeField] private new RangeEnemyConfig enemyConfig;
    protected override RangeEnemyConfig rangeEnemyConfig => enemyConfig;

    public override void SetStateMachine()
    {
        base.SetStateMachine();
    }
    public override void Init()
    {
        base.Init();
        movable = new MoveTowards(transform, rb, enemyConfig.speed, 100);
        attackDealer = new NoneAttack(animator);
        SetStateMachine();
    }
}
