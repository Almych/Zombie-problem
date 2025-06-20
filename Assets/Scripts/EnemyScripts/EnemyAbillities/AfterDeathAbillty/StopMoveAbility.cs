
using UnityEngine;

public class StopMoveAbility : Ability
{
    public StopMoveAbility(int coolDownTicks, bool callOnce, Enemy enemy) : base(coolDownTicks, callOnce, enemy)
    {
    }

    protected override void OnCall()
    {
        enemy.SetNewMoveProvider(new NoneMove(enemy, enemy.enemyConfig.speed));
    }

}
