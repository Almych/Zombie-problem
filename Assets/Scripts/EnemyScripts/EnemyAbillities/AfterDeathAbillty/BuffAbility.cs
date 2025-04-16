using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BuffAbility : MonoBehaviour, IDeathAbility
{
    [SerializeField] protected float detectRadius;
    protected RaycastHit2D[] hits;

    public virtual void onDeath()
    {
        hits = Physics2D.CircleCastAll(transform.position, detectRadius, Vector2.zero);
        
        for(int i = 0; i < hits.Length; i++)
        {
            if (hits[i].collider.GetComponent<ISpeedProvider>() != null)
            {
                Debug.Log(hits[i].collider.name);
                SetBuff(hits[i].collider.GetComponent<ISpeedProvider>());
            }
        }
    }

    protected abstract void SetBuff(ISpeedProvider movable);
}
