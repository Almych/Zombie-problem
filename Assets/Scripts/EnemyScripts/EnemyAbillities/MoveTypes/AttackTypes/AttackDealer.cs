using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeDealer : IAttackDealer
{
    private int attackCoolDown;
    private float attackDamage;
    private int currTicks = 0;
    private HealthBar healthBar;
    public MeleeDealer(float damage, int coolDownTicks, HealthBar health)
    {
        attackCoolDown = coolDownTicks;
        attackDamage = damage;
        healthBar = health;
    }

    public void Attack()
    {
        healthBar?.ChangeHealthValue(-attackDamage);
        currTicks = 0;
    }
}


public class RangeDealer : IAttackDealer
{
    private int attackCoolDown;
    private float attackDamage;
    private int currTicks = 0;
    private float _bulletSpeed;
    private Sprite _bulletSprite;
    private Transform _bulletTransform;
    public RangeDealer(float damage, int coolDownTicks, Sprite bulletSprite, float bulletSpeed, Transform shootPoint)
    {
        attackCoolDown = coolDownTicks;
        attackDamage = damage;
        _bulletSpeed = bulletSpeed;
        _bulletSprite = bulletSprite;
        _bulletTransform = shootPoint;
    }
    public void Attack()
    {
        EnemyBulletBehaivior enemyBullet = ObjectPoolManager.FindObject<EnemyBulletBehaivior>();
        if (enemyBullet != null)
        {
            enemyBullet.Activate(attackDamage, _bulletSprite, _bulletSpeed);
            enemyBullet.transform.position = _bulletTransform.position;
        }
    }
}
