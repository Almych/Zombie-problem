using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New AimItem", menuName = "ItemMenu/Items/AimItem")]
public class AimItem : ItemObject
{
    public float restoreHealth;

    public override void UseItem()
    {
       HealthBar.instance.ChangeHealthValue(restoreHealth);
    }

    private void Awake()
    {
        type = ItemType.Aim;
    }
}
