using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Aim,
    Granade,
    Bullet
}
public abstract class ItemObject : ScriptableObject
{
    public ItemType type;
    public Sprite prefab;
    [TextArea(15, 20)]public string description;
}
