using UnityEngine;
public abstract class RangeEnemy: Entity
{
    [SerializeField] protected float range;
    [SerializeField] protected LayerMask barrierMask;
    protected RaycastHit2D hit;
    protected abstract void DetectEnemy();
    public override void Init()
    {
        base.Init();
        UpdateSystem.OnUpdate += DetectEnemy;
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
        UpdateSystem.OnUpdate -= DetectEnemy;
    }
}