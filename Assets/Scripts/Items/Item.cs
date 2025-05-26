using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public abstract class Item : ScriptableObject
{
    public string Name;
    public Sprite Sprite;
    [TextArea(15, 20)]public string Description;

    public abstract void Use();
    public abstract void Initialize();
}

