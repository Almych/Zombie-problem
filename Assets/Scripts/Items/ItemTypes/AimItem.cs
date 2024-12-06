using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New AimItem", menuName = "ItemMenu/Items/AimItem")]
public class AimItem : ItemObject
{
    public float restoreHealth;

    private void Awake()
    {
        type = ItemType.Aim;
    }

    protected override void ItemAbillity()
    {
        HealthBar.instance.ChangeHealthValue(restoreHealth);
    }
}
