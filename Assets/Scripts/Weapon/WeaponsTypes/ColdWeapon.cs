using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
[CreateAssetMenu(fileName = "New Cold weapon", menuName = "Weapons/ColdWeapon")]
public class ColdWeapon : Weapon
{
    [Range(0.3f, 0.6f)]
    public float hitTime;
    public int maxHitAmount;
}
