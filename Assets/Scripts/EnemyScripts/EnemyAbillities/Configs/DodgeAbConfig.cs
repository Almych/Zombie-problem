using UnityEngine;
using System;
[CreateAssetMenu(fileName = "New DodgeAbilityConfig", menuName = "Ability/Dodge")]
public class DodgeAbilityConfig : AbilityConfig
{
    [SerializeField] private int timeToDodge;
    [SerializeField] float frequency, amplitute = 1f;

    public override Action ApplyAbilities(Enemy enemy)
    {
         resultAbility = new DodgeAbility(callPerTicks,callOnce,enemy, timeToDodge, frequency, amplitute);
         return base.ApplyAbilities(enemy);
    }
}
