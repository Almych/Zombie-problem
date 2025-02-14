using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Flame Damage", menuName = "Damage/ContinuesDamage/Flame Damage")]
public class FlameEffect : ContinuesDamage
{
   

    protected override void GetContinuesDamage(Entity enemy)
    {
         base.GetContinuesDamage(enemy);
    }

}
