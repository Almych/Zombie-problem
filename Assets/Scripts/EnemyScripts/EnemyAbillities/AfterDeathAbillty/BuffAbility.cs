using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BuffAbility : MonoBehaviour, IDeathAbility
{
    [SerializeField] protected float detectRadius;
    protected RaycastHit2D hit;

    public virtual void onDeath()
    {
        hit = Physics2D.CircleCast(transform.position, detectRadius, Vector2.one);
        IMovable move = hit.collider.GetComponent<IMovable>();
        if (move != null)
            SetBuff(move);
    }

    protected abstract void SetBuff(IMovable movable);
}
