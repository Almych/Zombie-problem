using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "Weapons")]
public class WeaponChoose : ScriptableObject
{
    [SerializeField] private Weapon weapon;
}

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] protected float damage;
    protected event Action WeaponDebaf;
}

