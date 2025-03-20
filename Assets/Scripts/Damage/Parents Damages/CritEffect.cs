using UnityEngine;
[CreateAssetMenu(fileName = "New Crit Effect", menuName = "DamageEffect/CritEffect")]
public class CritEffect : Damage
{
    [SerializeField] private float _critChance;
    [SerializeField] private float _maxCritChance = 10f;

    public override DamageType damageType => DamageType.Crit;

    public override void MakeDamage(Enemy enemy)
    {
        if (Random.value <= _critChance) 
        {
            enemy.TakeDamage(this);
        }

        enemy.TakeDamage(this);
    }
}
