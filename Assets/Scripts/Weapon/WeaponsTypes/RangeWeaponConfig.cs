using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Range Weapon", menuName = "Weapon/Range")]
public class RangeWeaponConfig : WeaponConfig
{
    [SerializeField] private Damage _damage;
    [SerializeField] private Sprite _weaponSprite;
    public float reloadTime;
    [Range(10, 20)] public float bulletSpeed = 10f;
    public int maxBullets;
    public Sprite bulletSprite;
    public override Damage damage { get => _damage; set => _damage = value; }
    public override Sprite weaponSprite { get => _weaponSprite; set => _weaponSprite = value; }
}
