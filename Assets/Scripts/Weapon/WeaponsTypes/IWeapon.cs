using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWeapon 
{
    public abstract Sprite weaponSprite { get; set; }
    void Execute();
}
