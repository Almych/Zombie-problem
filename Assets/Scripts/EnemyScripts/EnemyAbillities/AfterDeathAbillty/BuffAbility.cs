using UnityEngine;

public abstract class BuffAbility : Ability
{
    protected float detectRadius;
    protected RaycastHit2D[] hits;

    protected BuffAbility(int coolDownTicks, bool callOnce, Enemy enemy, float detectRadius) : base(coolDownTicks, callOnce, enemy)
    {
        this.detectRadius = detectRadius;
    }

    protected override void OnCall()
    {
        hits = Physics2D.CircleCastAll(enemy.transform.position, detectRadius, Vector2.zero);
        
        for(int i = 0; i < hits.Length; i++)
        {
            if (hits[i].collider.GetComponent<Enemy>() != null)
            {
                SetBuff(hits[i].collider.GetComponent<Enemy>());
                SetBuff(hits[i].collider.GetComponent<Enemy>().attackDealer);
            }
        }
    }

    protected abstract void SetBuff(ISpeedProvider movable);
}
