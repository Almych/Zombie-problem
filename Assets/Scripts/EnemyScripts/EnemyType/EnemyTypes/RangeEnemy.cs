using UnityEngine;
public abstract class RangeEnemy: Enemy
{
    [SerializeField] protected RangeEnemyConfig rangeEnemyConfig;
    [SerializeField] protected Transform shootPoint;
    protected RaycastHit2D hit;
    protected bool isDetected = false;
    protected override BaseEnemyConfig enemyConfig => rangeEnemyConfig;


    public override void Initiate()
    {
        isDetected = false;
        base.Initiate();
    }
    protected void DetectEnemy()
    {
        hit = Physics2D.Raycast(transform.position, Vector2.left, rangeEnemyConfig.detectRange, rangeEnemyConfig.player);
        if (hit.collider != null && !isDetected)
        {
            stateMachine?.SwitchState(attackState);
            isDetected = true;
        }
    }

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