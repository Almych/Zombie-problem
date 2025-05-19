using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
[CreateAssetMenu(fileName = "New Melee Weapon", menuName = "Weapon/Melee")]
public class MeleeWeaponConfig : WeaponConfig
{
    [SerializeField] private Damage _damage;
    [SerializeField] private Sprite _weaponSprite;
    [Range(0.5f, 2f)]
    public float hitSpeed;
    public override Damage damage { get => _damage; set => _damage = value; }
    public override Sprite weaponSprite { get => _weaponSprite; set => _weaponSprite = value; }
}
