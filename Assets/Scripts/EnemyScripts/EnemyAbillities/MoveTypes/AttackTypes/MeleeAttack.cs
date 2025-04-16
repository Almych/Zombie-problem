
using UnityEngine;

public class MeleeAttack : AttackProvider
{
    private float attackDamage;

    public MeleeAttack(Animator animator, float damage) : base(animator)
    {
        attackDamage = damage;
    }

    public override void ExecuteAttack(HealthBar health)
    {
        health?.ChangeHealthValue(-attackDamage);
    }
}
