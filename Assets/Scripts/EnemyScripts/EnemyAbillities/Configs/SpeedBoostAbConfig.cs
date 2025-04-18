using System;
using UnityEngine;

[CreateAssetMenu(fileName ="New SpeedBoostConfig", menuName ="Ability/SpeedBoost")]
public class SpeedBoostAbConfig : AbilityConfig
{
    [SerializeField, Range(0.1f, 1f)] private float speedBoost;
    [SerializeField] private float detectRadius;
    public override Action ApplyAbilities(Enemy enemy)
    {
        SpeedBoostAbility speedBoostAbility = new SpeedBoostAbility(enemy, detectRadius, speedBoost);
        return speedBoostAbility.OnDeath;
    }
}
