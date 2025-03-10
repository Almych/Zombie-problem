using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowards : MoveProvider
{
    public override void Move()
    {
        _rb.velocity = -transform.right * _speed;
    } 
}
