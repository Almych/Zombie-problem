using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForwardSpawn : SpawnAbility
{
    public ForwardSpawn(int coolDownTicks, bool callOnce, Enemy enemy, float horizontalSpace, Enemy spawnEnemy, ParticleSystem effect) : base(coolDownTicks, callOnce, enemy, horizontalSpace, spawnEnemy, effect)
    {
    }

    protected override void Spawn()
    {
        base.Spawn();
    }

    protected override void SpawnAtPoint(Enemy spawnEnemyTransform, ParticleSystem particle)
    {
        desirePosition = new Vector2(enemy.transform.position.x - horizontalSpawnSpace, enemy.transform.position.y);
        particle.transform.position = desirePosition;
        spawnEnemyTransform.transform.position = desirePosition;
        particle.gameObject.SetActive(true);
        spawnEnemyTransform.gameObject.SetActive(true);
        spawnEnemyTransform.Initiate(true);
    }
}
