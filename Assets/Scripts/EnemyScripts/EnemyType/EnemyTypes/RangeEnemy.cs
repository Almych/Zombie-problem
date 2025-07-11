using UnityEngine;
public abstract class RangeEnemy: Enemy
{
    [SerializeField] private RangeEnemyConfig config;
    [SerializeField] private Transform shootPoint;
    public override BaseEnemyConfig enemyConfig => config;
    protected RaycastHit2D hit;
    protected bool isDetected = false;
    public override Transform ShootPoint => shootPoint;

    public override void Initiate(bool isSpawnedByEnemy = false)
    {
        isDetected = false;
        base.Initiate();
    }
    protected void DetectEnemy()
    {
        hit = Physics2D.Raycast(transform.position, Vector2.left, config.detectRange, config.player);
        if (hit.collider != null && !isDetected)
        {
            CallDetectAbility();
            stateMachine?.SwitchState(attackState);
            isDetected = true;
        }
    }

    public override void Init()
    {
        base.Init();
        UpdateSystem.OnUpdate += DetectEnemy;
    }

    protected void OnDestroy()
    {
        UpdateSystem.OnUpdate -= DetectEnemy;
    }

}