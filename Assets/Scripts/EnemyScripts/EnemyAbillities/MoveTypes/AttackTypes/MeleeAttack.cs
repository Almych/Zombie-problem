
using UnityEngine;

public class MeleeAttack : AttackProvider
{
    private float attackDamage;

    public MeleeAttack(Animator animator, int attackPerTicks, float damage) : base(animator, attackPerTicks)
    {
        attackDamage = damage;
    }

    public override void ExecuteAttack(HealthBar health)
    {
        health?.TakeDamage(attackDamage);
    }
}
