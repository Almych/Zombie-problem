using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : IWeapon
{
    private Enemy enemy;
    private MeleeWeaponConfig _meleeConfig;
    public Sprite weaponSprite { get => _meleeConfig.weaponSprite; set => _meleeConfig.weaponSprite = value; }
    public MeleeWeapon(MeleeWeaponConfig weaponConfig)
    {
        _meleeConfig = weaponConfig;
    }


    public void Execute()
    {
        if(enemy != null)
        _meleeConfig.damage.MakeDamage(enemy);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        enemy = collision.collider?.GetComponent<Enemy>();
    }
}
