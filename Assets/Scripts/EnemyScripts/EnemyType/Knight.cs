

public class Knight : MeleeEnemy
{
    protected override IAttackDealer SetAttack()
    {
        return attackDealer = new MeleeAttack(meleeEnemyConfig.damage);
    }

    protected override IMovable SetMove()
    {
        return movable = new MoveTowards(rb, transform, 2f);
    }

}
