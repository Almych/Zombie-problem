using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Aim,
    Granade,
    Bullet,
    Weapon
}
public abstract class Item : ScriptableObject
{
    public int amount;
    public readonly int stackSize;
    public Sprite sprite;
    [TextArea(15, 20)]public string description;

    public abstract void Use();
}

