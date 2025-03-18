using UnityEngine;
public interface IEnemy
{
    void Initiate();
    void Attack();
    void TakeDamage(Damage damage);
    void Die();
}
public abstract class Entity : MonoBehaviour, IEnemy
{
    [SerializeField] protected int maxHealth;
    [SerializeField] protected EnemyUniqDefense defense;
    protected float currHealth;
    protected Animator animator;
    protected Rigidbody2D rb;
    protected Collider2D enemyCollider;
    protected MoveProvider moveProvider;
    protected IAttackDealer attackDealer;
    protected IDeathAbility deathAbility;
    protected RunState runState;
    protected DieState dieState;
    protected AttackState attackState;
    protected StateMachine stateMachine;
    void Awake()
    {
        Init(); //Call it in Awake cuz after pooling immediatly init nessesary data
    }
    public void TakeDamage(Damage damage)
    {
        currHealth -= defense.Defense(damage);
        if (currHealth <= 0)
        {
            stateMachine.SwitchState(dieState);
        }
    }

    public virtual void Init()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        enemyCollider = GetComponent<Collider2D>();
        moveProvider = GetComponent<MoveProvider>();
        runState = new RunState(animator, moveProvider);
        attackState = new AttackState(animator, this);
        dieState = new DieState(animator);
        deathAbility = GetComponent<IDeathAbility>();
        stateMachine = new StateMachine(runState, attackState, dieState);
        UpdateSystem.OnUpdate += stateMachine.OnTick;
    }

    public virtual void Initiate()
    {
        currHealth = maxHealth;
        stateMachine.SwitchState(runState);
    }


    public void Die()
    {
        deathAbility?.onDeath();
        gameObject.SetActive(false);
    }
    

  

    protected virtual void OnDestroy()
    {
            UpdateSystem.OnUpdate -= stateMachine.OnTick;
    }

    //Attack ability calls in animation
    public abstract void Attack();
}
