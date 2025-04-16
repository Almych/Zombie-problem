using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mage : RangeEnemy
{
    [SerializeField] private new RangeEnemyConfig enemyConfig;
    protected override RangeEnemyConfig rangeEnemyConfig => enemyConfig;

    public override void Init()
    {
        base.Init();
    }
}
