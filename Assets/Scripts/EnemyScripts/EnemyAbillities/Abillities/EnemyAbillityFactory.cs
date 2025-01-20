using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum OnDamageAbillity
{
    None, 
    MoveDiagnol,
};
public enum OnDeathAbillity
{
    None,
    Spawn
}


public static class EnemyAbillityFactory 
{
    public static OnDamageEnemyAbillity OnDamageAbillityAdd(EnemyOnDamageAbillityConfig damageAbillityType, Entity mono)
    {
        switch(damageAbillityType.onDamageAbillity)
        {
            case OnDamageAbillity.None:
                return null;

            case OnDamageAbillity.MoveDiagnol:
                if (damageAbillityType is MoveDiagnolConfig move)
                {
                    OnDamageEnemyAbillity abillity = new MoveDiagnolAbillity(mono);
                    return abillity;
                }else
                {
                    return null;
                }

            default:
                return null;
                
        }
    }

    public static OnDeathEnemyAbillity OnDeathAbillityAdd( EnemyOnDeathAbillityConfig deathAbillityType, Entity mono)
    {
        switch (deathAbillityType.OnDeathAbillity)
        {
            case OnDeathAbillity.None:
                return null;

            case OnDeathAbillity.Spawn:
                if (deathAbillityType is SpawnAbillityConfig spawn)
                {
                    OnDeathEnemyAbillity abillity = new SpawnAbillity(mono,spawn.enemyToSpawn,spawn.amountToSpawn);
                    return abillity;
                }
                else
                {
                    return null;
                }

            default:
                return null;
        }
    }
}
