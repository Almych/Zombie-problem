using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAbilityFactory : MonoBehaviour
{
    public void AddOnDeathAbility(EnemyOnDeathAbilities ability, Entity unit)
    {
        switch(ability)
        {
            case EnemyOnDeathAbilities.None:
                break;
            case EnemyOnDeathAbilities.Spawnable:
            
                break;
        }
    }
}
