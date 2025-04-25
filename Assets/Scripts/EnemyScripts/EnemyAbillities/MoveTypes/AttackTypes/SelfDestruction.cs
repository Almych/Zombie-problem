

using UnityEngine;

public class NoneAttack : AttackProvider
{
    public NoneAttack(Animator animator, int attackPerTicks) : base(animator, attackPerTicks)
    {
    }

    public override void ExecuteAttack(HealthBar healthBar = null)
    {
        
    }
}
