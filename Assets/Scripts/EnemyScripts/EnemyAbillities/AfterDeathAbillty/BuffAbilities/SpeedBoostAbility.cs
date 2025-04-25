using UnityEngine;

public class SpeedBoostAbility : BuffAbility
{
     private float speedBoost;

    public SpeedBoostAbility(int coolDownTicks, bool callOnce, Enemy enemy, float detectRadius, float speedBoost) : base(coolDownTicks, callOnce, enemy, detectRadius)
    {
        this.speedBoost = speedBoost;
    }

    protected override void SetBuff(ISpeedProvider movable)
    {
        movable.IncreaseSpeed(speedBoost);
    }
}
