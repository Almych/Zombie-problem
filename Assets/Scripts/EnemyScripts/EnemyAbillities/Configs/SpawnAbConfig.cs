using System;
using UnityEngine;

[CreateAssetMenu(fileName = "New SpawnAbConfig", menuName = "Ability/Spawn")]
public class SpawnAbConfig : AbilityConfig
{
    [Header("Make sure you add spawned zombie to the pool!")]
    [SerializeField, Range(1, 2)] private int spawnAmount;
    [SerializeField, Range(0, 1f)] private float spawnSpace;
    [SerializeField] private Enemy spawnEnemy;
    public override Action ApplyAbilities(Enemy enemy)
    {
        if (spawnAmount > 1)
        {
            HorizontalSpawn horizontalSpawn = new HorizontalSpawn(enemy, spawnSpace, spawnEnemy);
            return horizontalSpawn.OnDeath;
        }
        else
        {
            ForwardSpawn forwardSpawn = new ForwardSpawn(enemy, spawnSpace,spawnEnemy);
            return forwardSpawn.OnDeath;
        }
    }
}
