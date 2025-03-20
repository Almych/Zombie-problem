using UnityEngine;

public class Archer : RangeEnemy
{
   
    protected override IAttackDealer SetAttack()
    {
        return new RangeDamage(rangeEnemyConfig.bulletConfig, shootPoint);
    }

    protected override IMovable SetMove()
    {
       return  new MoveTowards(rb, transform, 1f);
    }

   
}
