using UnityEngine;

public class SpeedBoostAbility : BuffAbility
{
     private float speedBoost;

    public SpeedBoostAbility(Enemy enemy, float detectRadius, float speedBoost) : base(enemy, detectRadius)
    {
        this.speedBoost = speedBoost;
    }

    public override void OnDeath()
    {
        base.OnDeath();
    }
    protected override void SetBuff(ISpeedProvider movable)
    {
        movable.IncreaseSpeed(speedBoost);
    }
}
