

public class Ram : MeleeEnemy
{
    protected override IAttackDealer SetAttack()
    {
       return attackDealer = new SelfDestruction(animator);
    }

    protected override IMovable SetMove()
    {
        return movable = new MoveTowards(rb, transform, 1f);
    }

   
}
