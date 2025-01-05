using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyOnDamageAbillity", menuName = "EnemyOnDamageAbillity/None")]
public class EnemyOnDamageAbillityConfig : ScriptableObject
{
    public OnDamageAbillity onDamageAbillity;
}
