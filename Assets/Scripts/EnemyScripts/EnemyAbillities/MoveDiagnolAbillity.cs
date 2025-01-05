using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDiagnolAbillity : OnDamageEnemyAbillity
{
    private const float coolDownTime = 0.5f;
    private float _speed;
    private MonoBehaviour mono;
    private static IEnumerator currCoroutine;

    public MoveDiagnolAbillity(Transform unit, Rigidbody2D unitRb, float speed, MonoBehaviour mono) : base(unit, unitRb)
    {
        _speed = speed;
        this.mono = mono;
        currCoroutine = null;
    }

    private IEnumerator MoveDiagnol()
    {
        float dir = Random.Range(1, 10);
        if (dir >= 5)
        {
            _unitRb.velocity = -_unit.right + Vector3.up * _speed;
        }
        else
        {
            _unitRb.velocity = -_unit.right + Vector3.down * _speed;
        }

        yield return new WaitForSeconds(coolDownTime);
        _unitRb.velocity = -_unit.right * _speed;
        currCoroutine = null;
    }

    public override void OnDamage()
    {
        if (currCoroutine != null)
        {
            mono.StopCoroutine(currCoroutine);
            currCoroutine = null;
        }
            currCoroutine = MoveDiagnol();
            mono.StartCoroutine(currCoroutine);
    }
}
