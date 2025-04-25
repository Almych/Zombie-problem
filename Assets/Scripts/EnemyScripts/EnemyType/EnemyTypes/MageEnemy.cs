using UnityEngine;

public abstract class MageEnemy : Enemy
{
    [SerializeField] private RangeEnemyConfig config;
    [SerializeField] private Transform shootPoint;
    [SerializeField] private float moveDuration = 10f;
    [SerializeField] private float attackDuration = 5f;

    protected internal override BaseEnemyConfig enemyConfig => config;
    protected internal override Transform ShootPoint => shootPoint;

    private float actionTimer;
    private bool isMoving = true;

    public override void Initiate()
    {
        base.Initiate();
        isMoving = true;
        actionTimer = moveDuration;
        UpdateSystem.OnUpdate += MageBehaviorLoop;
    }

    protected void OnDestroy()
    {
        UpdateSystem.OnUpdate -= DetectEnemy;
    }

    private void MageBehaviorLoop()
    {
        Debug.Log("MAgging");
        actionTimer--;
        Debug.Log(actionTimer);
        if (actionTimer <= 0)
        {
            if (isMoving)
            {
                Debug.Log("Switched to move");
                stateMachine.SwitchState(attackState);
                actionTimer = attackDuration;
            }
            else
            {
                Debug.Log("Switched to attack");
                stateMachine.SwitchState(runState);
                actionTimer = moveDuration;
            }
            isMoving = !isMoving;
        }
    }

    protected void DetectEnemy()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.left, config.detectRange, config.player);
        if (hit.collider != null)
        {
            CallDetectAbility();
            stateMachine.SwitchState(attackState);
            UpdateSystem.OnUpdate -= MageBehaviorLoop;
        }
    }

    public override void Init()
    {
        base.Init();
        UpdateSystem.OnUpdate += DetectEnemy;
    }
}

