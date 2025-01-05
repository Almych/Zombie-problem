using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyOnDamageAbillity", menuName = "EnemyOnDamageAbillity/MoveDiagnolAbillity")]
public class MoveDiagnolConfig : EnemyOnDamageAbillityConfig
{
    public readonly new OnDamageAbillity onDamageAbillity = OnDamageAbillity.MoveDiagnol;
}
