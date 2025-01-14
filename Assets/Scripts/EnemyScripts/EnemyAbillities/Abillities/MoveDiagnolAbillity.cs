using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDiagnolAbillity : OnDamageEnemyAbillity
{
    private const float coolDownTime = 0.5f;
    private float _speed;
    private Entity mono;
    private static IEnumerator currCoroutine;

    public MoveDiagnolAbillity(Entity enemy) : base(enemy)
    {
        mono = enemy;
        _speed = enemy.enemyData.speed;
    }

    private IEnumerator MoveDiagnol()
    {
        float dir = Random.Range(1, 10);
        if (dir >= 5)
        {
            rb.velocity = -transform.right + Vector3.up * _speed;
        }
        else
        {
            rb.velocity = -transform.right + Vector3.down * _speed;
        }

        yield return new WaitForSeconds(coolDownTime);
        if (currCoroutine != null && mono.stateMachine.currentState != mono.stateMachine.deadState)
        {
            rb.velocity = -transform.right * _speed;
        }
    }

    public override void OnDamage()
    {
        if (currCoroutine != null)
        currCoroutine = null;

        currCoroutine = MoveDiagnol();
        mono.StartCoroutine(currCoroutine);
    }
}
