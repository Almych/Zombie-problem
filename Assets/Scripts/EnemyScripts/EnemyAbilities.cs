using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDiagnolMovable 
{
    public void MoveDiagnol(float coolDownTime);
}

public interface ISpawnable
{
    public void Spawn();
}

public interface IAttackOnce
{
    public void AttackOnce();
}
