using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RangedEnemy : Entity
{
    [SerializeField] protected float attackDistance;
    [SerializeField] protected float detectTime;
    [SerializeField] protected LayerMask triggerMask;
    [SerializeField] protected Sprite bulletSprite;
    [SerializeField] protected float bulletSpeed;
    protected RaycastHit2D hit;
    protected abstract IEnumerator DetectEnemy();
}
