using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "Weapon", menuName = "Weapons")]
public class Weapon : ScriptableObject
{
    public int bulletMax;
    public float realodTime;
    public float damage;
    public Sprite iconOfWeapon;
}
