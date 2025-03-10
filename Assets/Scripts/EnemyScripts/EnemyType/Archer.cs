using System.Collections;
using UnityEngine;

public class Archer : RangeEnemy
{
    [SerializeField] private float damage;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private Sprite bulletSprite;
    [SerializeField] private int attackCoolDownTick;
    [SerializeField] private Transform bulletTransform;
    private bool isDetected;

    public override void Attack()
    {
        base.Attack();
    }
    public override void Init()
    {
        attackDealer = new RangeDealer(damage, attackCoolDownTick, bulletSprite, bulletSpeed, bulletTransform);
        base.Init();
    }

    protected override void DetectEnemy()
    {
        if (isDetected)
            return;
        hit = Physics2D.Raycast(transform.position, Vector2.left, range, barrierMask);
        if (hit.collider != null)
        {
            stateMachine.SwitchState(attackState);
            isDetected = true;
        }
    }
}
