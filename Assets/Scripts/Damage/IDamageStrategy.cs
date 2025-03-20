using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageStrategy 
{
    public DamageType damageType { get;}
    void MakeDamage(Enemy enemy);
    float GetDamage();
}
