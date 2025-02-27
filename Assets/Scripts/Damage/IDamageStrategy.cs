using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageStrategy 
{
    void MakeDamage(Entity enemy);
    float GetDamage();
}
