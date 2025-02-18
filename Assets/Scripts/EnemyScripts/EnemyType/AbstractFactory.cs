using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemyFactory
{
    IEnemy CreateMeleeEnemy();
    IEnemy CreateRangedEnemy();
}

public abstract class EnemyFactory : IEnemyFactory
{
    public abstract IEnemy CreateMeleeEnemy();

    public abstract IEnemy CreateRangedEnemy();
}
