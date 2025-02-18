using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieFactory : EnemyFactory
{
    public override IEnemy CreateMeleeEnemy()
    {
        throw new System.NotImplementedException();
    }

    public override IEnemy CreateRangedEnemy()
    {
        throw new System.NotImplementedException();
    }
}
