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
    public static OnDamageEnemyAbillity OnDamageAbillityAdd(OnDamageAbillity damageAbillityType, Entity enemy)
    {
        switch(damageAbillityType)
        {
            case OnDamageAbillity.None:
                return null;

            case OnDamageAbillity.MoveDiagnol:
               OnDamageEnemyAbillity abillity = new MoveDiagnolAbillity(enemy.transform, enemy.rb, enemy.enemyData.speed, enemy);
                return abillity;

            default:
                return null;
                
        }
    }

    public static OnDeathEnemyAbillity OnDeathAbillityAdd( OnDeathAbillity deathAbillityType, Entity enemy)
    {
        switch (deathAbillityType)
        {
            case OnDeathAbillity.None:
                return null;

            case OnDeathAbillity.Spawn:
                OnDeathEnemyAbillity abillity = new SpawnAbillity(enemy.transform, enemy.rb,2, enemy);
               return abillity;

            default:
                return null;
        }
    }
}
