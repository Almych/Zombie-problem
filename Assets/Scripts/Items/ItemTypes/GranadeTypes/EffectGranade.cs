using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New EffectGrenade", menuName = "ItemMenu/Items/Grenades/EffectGrenade")]
public class EffectGrenade : Grenade
{
    [SerializeField] private int effectTimeTicks;

    public override void Use()
    {
       EventBus.Publish(new FreezeEnemiesEvent(effectTimeTicks));
    }
}
