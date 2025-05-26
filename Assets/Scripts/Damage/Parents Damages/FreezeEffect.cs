using System.Collections;
using UnityEngine;
[CreateAssetMenu(fileName = "New Freeze Effect", menuName = "DamageEffect/FreezeEffect")]
public class FreezeEffect : EffectDamageDecorator
{
    [SerializeField, Range(0.1f, 1f)] private float _slowAmount;
    [SerializeField, Range(3f, 6f)] private float slowDuration;
    [SerializeField, Range(0.1f, 1f)] private float freezeChance;
    private const int freezeDuration = 5;

   

    public override DamageType damageType => DamageType.Freeze;

    public override void ApplyEffect(Enemy enemy)
    {
        enemy.StartCoroutine(SlowEnemy(enemy));
        if (Random.Range(0.1f, 1) <= freezeChance)
            enemy.RequestStun(freezeDuration, StunType.Froze);
    }

    public override void MakeDamage(Enemy enemy)
    {
        defaultDamage?.MakeDamage(enemy);
        ApplyEffect(enemy);
    }

    private IEnumerator SlowEnemy(Enemy enemy)
    {
        enemy.ReduceSpeed(_slowAmount);
        enemy.SetColor(Color.lightBlue);
        yield return new WaitForSeconds(slowDuration);
        enemy.ResetSpeed();
        enemy.SetColor(Color.white);
    }
}
