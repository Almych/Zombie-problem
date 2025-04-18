using UnityEngine;
using System;
[CreateAssetMenu(fileName = "New DodgeAbilityConfig", menuName = "Ability/Dodge")]
public class DodgeAbilityConfig : AbilityConfig
{
    [SerializeField] private int timeToDodge;
    [SerializeField] float frequency, amplitute = 1f;

    public override Action ApplyAbilities(Enemy enemy)
    {
         DodgeAbility dodgeAbility = new DodgeAbility(enemy, timeToDodge, frequency, amplitute);
        return dodgeAbility.OnMove; 
    }
}
