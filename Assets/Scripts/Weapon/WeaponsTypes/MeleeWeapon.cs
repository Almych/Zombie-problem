using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : IWeapon
{
    private Enemy enemy;
    private MeleeWeaponConfig _meleeConfig;
    public MeleeWeapon(MeleeWeaponConfig weaponConfig)
    {
        _meleeConfig = weaponConfig;
    }

    public void Execute()
    {
        enemy?.TakeDamage(_meleeConfig.damage);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        enemy = collision.collider?.GetComponent<Enemy>();
    }
}
