using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum OnDamageAbility
{
    None, 
    MoveDiagonal,
};
public enum OnDeathAbility
{
    None,
    Spawn
}


public static class EnemyAbilityFactory 
{
    //public static OnDamageEnemyAbility OnDamageAbilityAdd(EnemyOnDamageAbilityConfig damageAbilityType, Entity mono)
    //{
    //    switch(damageAbilityType.GetOnDamageAbility())
    //    {
    //        case OnDamageAbility.None:
    //            return null;

    //        case OnDamageAbility.MoveDiagonal:
    //            if (damageAbilityType is MoveDiagonalConfig move)
    //            {
    //                OnDamageEnemyAbility ability = new MoveDiagonalAbility(mono);
    //                return ability;
    //            }
    //            else
    //                return null;
    //        default:
    //            return null;
                
    //    }
    //}

    //public static OnDeathEnemyAbility OnDeathAbilityAdd(EnemyOnDeathAbilityConfig deathAbilityType, Entity mono)
    //{
    //    switch (deathAbilityType.GetOnDeathAbility())
    //    {
    //        case OnDeathAbility.None:
    //            return null;

    //        case OnDeathAbility.Spawn:
    //            if (deathAbilityType is SpawnAbilityConfig spawn)
    //            {
    //                OnDeathEnemyAbility ability = new SpawnAbility(mono,spawn.enemyToSpawn,spawn.amountToSpawn);
    //                return ability;
    //            }
    //            else
    //            {
    //                return null;
    //            }

    //        default:
    //            return null;
    //    }
    //}
}
