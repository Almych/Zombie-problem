using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Flame Effect", menuName = "DamageEffect/FlameEffect")]
public class FlameEffect : ContinuesDamageDecorator
{

    public override DamageType damageType => DamageType.Flame;
}
