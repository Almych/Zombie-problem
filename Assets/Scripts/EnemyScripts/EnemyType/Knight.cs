

public class Knight : MeleeEnemy
{
    public override void SetStateMachine()
    {
        base.SetStateMachine();
    }
    public override void Init()
    {
        base.Init();
        attackDealer = new MeleeAttack(animator, meleeEnemyConfig.damage);
        movable = new MoveTowards(transform, rb, meleeEnemyConfig.speed, 20);
        SetStateMachine();
    }
}
