using UnityEngine;
[CreateAssetMenu(fileName = "New Default Effect", menuName = "DamageEffect/DefaultEffect")]
public class DefaultDamage : Damage
{

    public override DamageType damageType => DamageType.Default;

    public override void MakeDamage(Entity enemy)
    {
        enemy.TakeDamage(this);
    }
}
