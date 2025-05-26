using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New AimItem", menuName = "ItemMenu/Items/AimItem")]
public class AimItem : Item
{
    public int healPoints;

    public override void Initialize()
    {
    }

    public override void Use()
    {
        EventBus.Publish(new OnHealEvent(healPoints));
    }
}
