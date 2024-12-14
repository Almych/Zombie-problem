using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyOnDamageAbilities 
{
    None,
    MoveDiagnolable
}

public enum EnemyOnDeathAbilities
{
    None,
    Spawnable
}

public abstract class EnemyAbillity : MonoBehaviour
{
    protected Transform _unit;
    protected Rigidbody2D _unitRb;
    protected Entity _enemy;
    public EnemyAbillity(Transform unit, Rigidbody2D rb, Entity enemy)
    {
        _unit = unit;
        _unitRb = rb;
        _enemy = enemy; 
    }

    public abstract void UniqAbillityUse();

    private void OnEnable()
    {
     
    }
}
public class DiagnolMoveAbility: EnemyAbillity 
{
    private const float coolDownTime = 2f;
    private float _speed;
    public DiagnolMoveAbility(Transform unit, Rigidbody2D rb, Entity enemy, float speed) : base(unit, rb, enemy)
    {
        _speed = speed;
    }

    private IEnumerator MoveDiagnol()
    {
        float dir = UnityEngine.Random.Range(1, 10);
        if (dir >= 5)
        {
            _unitRb.velocity = -_unit.right + Vector3.up * _speed;
        }else
        {
            _unitRb.velocity = -_unit.right + Vector3.down * _speed;
        }
        yield return new WaitForSeconds(coolDownTime);
        _unitRb.velocity = -_unit.right * _speed;

    }

    public override void UniqAbillityUse()
    {
        StartCoroutine(MoveDiagnol());
    }
}

public class SpawnAbility : EnemyAbillity
{
    private int _amount;
    private Entity _entity;
    public SpawnAbility(Transform unit, Rigidbody2D rb, int amount, Entity enemy, Entity enemyType) : base(unit, rb, enemy)
    {
        _amount = amount;
        _entity = enemyType;
    }

    public void SpawnEnemy()
    {
        for(int i = 0; i < _amount; i++)
        {
            Entity spawnEnemy = EnemyPool.Instance.GetZombie(_entity);
            spawnEnemy.Initiate();
        }
    }

    public override void UniqAbillityUse()
    {
       SpawnEnemy();
    }
}
