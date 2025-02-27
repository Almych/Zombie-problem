using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoostAbility : BuffAbility
{
    [SerializeField] private float speedBuff;

    public override void onDeath()
    {
        base.onDeath();
    }
    protected override void SetBuff(IMovable movable)
    {
        Debug.Log("Added");
        movable = new MoveBoostDecorator(movable, speedBuff );
        movable.Move();
    }
}
