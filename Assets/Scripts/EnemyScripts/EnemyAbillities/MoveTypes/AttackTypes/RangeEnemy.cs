using UnityEngine;
public abstract class RangeEnemy: Entity
{
    [SerializeField] protected float range;
    [SerializeField] protected LayerMask barrierMask;
    protected RaycastHit2D hit;
    protected abstract void DetectEnemy();
    protected override void OnEnable()
    {
        base.OnEnable();
        UpdateSystem.OnUpdate += DetectEnemy;
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        UpdateSystem.OnUpdate -= DetectEnemy;
    }
}