using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAttack : AttackType
{
    protected Sprite bulletPrefab;
    protected float speedOfBullet;
    protected float damage;
    public RangedAttack(float damage, Sprite bulletSprite, float speed)
    {
        this.damage = damage;
        bulletPrefab = bulletSprite;
        speedOfBullet = speed;
    }

    public override void Attack(HealthBar healthBar)
    {
        EnemyBulletBehaivior bullet =  ObjectPoolManager.FindObject<EnemyBulletBehaivior>();
        if (bullet != null)
        { 
            bullet.Activate(damage, bulletPrefab, speedOfBullet);
        }
    }
}
