using System;
using System.Collections;
using UnityEngine;

public abstract class EffectDamage : Damage
{
    [SerializeField] protected float stunTime;
    [Range(1, 7)][SerializeField] protected float effectChance;
    private Entity currentEnemy;


    public override void MakeDamage(Entity enemy)
    {
        throw new NotImplementedException();
    }

    protected IEnumerator StunEnemy()
    {
        if (CanUseEffect())
        {
            currentEnemy?.Stun();
            yield return new WaitForSeconds(stunTime);
            currentEnemy?.Initiate();
        }
    }

    private bool CanUseEffect()
    {
        var chance = UnityEngine.Random.Range(1, 10);
        return effectChance >= chance;
    }

    public void StopUniqueDamage()
    {
       
    }
}
