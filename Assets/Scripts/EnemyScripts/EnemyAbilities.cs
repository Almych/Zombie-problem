using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IEnemyAbillity
{
}
public class DiagnolMove: MonoBehaviour, IEnemyAbillity 
{
    private const float coolDownTime = 2f;
    public IEnumerator MoveDiagnol(Rigidbody2D unitRb, Transform unit, float speed)
    {
        float dir = UnityEngine.Random.Range(1, 10);
        if (dir >= 5)
        {
            unitRb.velocity = -transform.right + Vector3.up * speed;
        }else
        {
            unitRb.velocity = -transform.right + Vector3.down * speed;
        }
        yield return new WaitForSeconds(coolDownTime);
        unitRb.velocity = -transform.right * speed;

    }
}

public class Spawn : IEnemyAbillity
{
    public void SpawnEnemy(Entity enemyType, int amount)
    {

    }
}
