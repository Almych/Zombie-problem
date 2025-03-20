
using UnityEngine;

public class SelfDestruction : IAttackDealer
{
    private Animator _animator;
    public SelfDestruction(Animator animator) 
    {
       _animator = animator;
    }
    public void ExecuteAttack(HealthBar health = null)
    {
        _animator.SetTrigger("Die");
    }
}
