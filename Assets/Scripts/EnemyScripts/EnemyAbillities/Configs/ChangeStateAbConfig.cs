using System;
using UnityEngine;

[CreateAssetMenu(fileName = "New ChangeStateAbConfig", menuName = "Ability/ChangeState")]
public class ChangeStateAbConfig : AbilityConfig
{
    [Header("0:RunState, 1:AttackState, 2:DieState")][SerializeField, Range(0, 2)] private int stateNumber;
    public override Action ApplyAbilities(Enemy enemy)
    {
        resultAbility = new ChangeStateAbility(callPerTicks, callOnce,enemy, stateNumber);
        return base.ApplyAbilities(enemy);
    }
}
