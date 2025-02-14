using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Poisen Damage", menuName = "Damage/ContinuesDamage/Poisen Damage")]
public class PoisenEffect : ContinuesDamage
{
    

    protected override void GetContinuesDamage(Entity enemy)
    {
        base.GetContinuesDamage(enemy);
    }
}
