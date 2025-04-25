
using System;
using UnityEngine;
[CreateAssetMenu(fileName = "New SpeedBoostConfig", menuName = "Ability/StopMove")]
public class StopMoveAbConfig : AbilityConfig
{
    public override Action ApplyAbilities(Enemy enemy)
    {
        resultAbility = new StopMoveAbility(callPerTicks,callOnce,enemy);
        return base.ApplyAbilities(enemy);
    }
}
