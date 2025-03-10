using UnityEngine;

public abstract class MeleeEnemy : Entity
{
    protected HealthBar healthBar;

    protected abstract void OnCollisionEnter2D(Collision2D collision);
}

public abstract class RangeEnemy: Entity
{
    [SerializeField] protected float range;
    [SerializeField] protected LayerMask barrierMask;
    protected RaycastHit2D hit;
    protected abstract void DetectEnemy();
    protected override void OnEnable()
    {
        base.OnEnable();
        TickSystem.OnTick += DetectEnemy;
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        TickSystem.OnTick -= DetectEnemy;
    }
}