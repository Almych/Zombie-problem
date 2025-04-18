using UnityEngine;

public abstract class BuffAbility : IDeathAbility
{
    protected Enemy enemy;
    protected float detectRadius;
    protected RaycastHit2D[] hits;

    protected BuffAbility(Enemy enemy, float detectRadius)
    {
        this.enemy = enemy;
        this.detectRadius = detectRadius;
    }

    public virtual void OnDeath()
    {
        hits = Physics2D.CircleCastAll(enemy.transform.position, detectRadius, Vector2.zero);
        
        for(int i = 0; i < hits.Length; i++)
        {
            if (hits[i].collider.GetComponent<Enemy>() != null)
            {
                SetBuff(hits[i].collider.GetComponent<Enemy>().movable);
                SetBuff(hits[i].collider.GetComponent<Enemy>().attackDealer);
            }
        }
    }

    protected abstract void SetBuff(ISpeedProvider movable);
}
