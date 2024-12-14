using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GroundEnemy : Entity
{
    [SerializeField] private float speed;
    public override void Initiate()
    {
       rb.velocity = -transform.right * speed;
    }
}
