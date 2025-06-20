using System;
using UnityEngine;

[CreateAssetMenu(fileName = "New SpawnAbConfig", menuName = "Ability/Spawn")]
public class SpawnAbConfig : AbilityConfig
{
    [Header("Make sure you add spawned zombie to the pool!")]
    [SerializeField, Range(1, 2)] private int spawnAmount;
    [SerializeField, Range(0, 1f)] private float spawnSpace;
    [SerializeField] private Enemy spawnEnemy;
    [SerializeField] private ParticleSystem spawnParticle;
    public override Action ApplyAbilities(Enemy enemy)
    {
        if (spawnAmount > 1)
        {
            resultAbility = new HorizontalSpawn(callPerTicks, callOnce, enemy, spawnSpace, spawnEnemy, spawnParticle);
        }
        else
        {
            resultAbility = new ForwardSpawn(callPerTicks, callOnce, enemy, spawnSpace, spawnEnemy, spawnParticle);
        }
        return base.ApplyAbilities(enemy);
    }
}
