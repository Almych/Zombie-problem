using UnityEngine;

public abstract class MeleeEnemy : Entity
{
    [SerializeField] protected float damage;
    protected HealthBar healthBar;
    protected abstract void OnCollisionEnter2D(Collision2D collision);
}
