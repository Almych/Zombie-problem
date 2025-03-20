using UnityEngine;

public class MeleeAttack : IAttackDealer
{
    private float attackDamage;
    public MeleeAttack(float damage)
    {
        attackDamage = damage;
    }

    public void ExecuteAttack(HealthBar health)
    {
        health?.ChangeHealthValue(-attackDamage);
    }
}
