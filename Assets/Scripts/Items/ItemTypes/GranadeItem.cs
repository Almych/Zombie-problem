using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New AimItem", menuName = "ItemMenu/Items/Granades")]
public class GranadeItem : ItemObject
{
    public Granade granade;

    private void Awake()
    {
        type = ItemType.Granade;
    }


}
