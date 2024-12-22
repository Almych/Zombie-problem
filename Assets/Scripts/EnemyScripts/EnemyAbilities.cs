using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
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

public static class AbillityFactory
{
    public static void AddAbillity(EnemyOnDamageAbilities ability)
    {
        switch (ability)
        {
            case EnemyOnDamageAbilities.None:
                break;
            case EnemyOnDamageAbilities.MoveDiagnolable:
                break;
        }
    }
}

public abstract class EnemyAbillity : YieldInstruction
{
    protected Transform _unit;
    protected Rigidbody2D _unitRb;
    public EnemyAbillity(Transform unit, Rigidbody2D rb)
    {
        _unit = unit;
        _unitRb = rb;
    }

    public abstract void UniqAbillityUse();

    
}
public class DiagnolMoveAbility: EnemyAbillity 
{
    private const float coolDownTime = 2f;
    private float _speed;
    private MonoBehaviour mono;
    public DiagnolMoveAbility(Transform unit, Rigidbody2D rb, float speed, MonoBehaviour mono) : base(unit, rb)
    {
        _speed = speed;
        this.mono = mono;
    }

    private IEnumerator MoveDiagnol()
    {
            float dir = UnityEngine.Random.Range(1, 10);
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
    }

    public override void UniqAbillityUse()
    {
        mono.StartCoroutine(MoveDiagnol());
    }
}

public class SpawnAbility : EnemyAbillity
{
    private int _amount;
    private Entity _entity;
    public SpawnAbility(Transform unit, Rigidbody2D rb, int amount, Entity enemyType) : base(unit, rb)
    {
        _amount = amount;
        _entity = enemyType;
    }

    public void SpawnEnemy()
    {
        for(int i = 0; i < _amount; i++)
        {
            Entity spawnEnemy = EnemyPool.Instance.GetZombie(_entity);
            if (spawnEnemy != null)
            {
                var randomYPositon = UnityEngine.Random.Range(-1, 1);
                spawnEnemy.transform.position = new Vector3(_unit.position.x, _unit.transform.position.y + randomYPositon, 0);
                spawnEnemy.Initiate();
            }
        }
    }

    public override void UniqAbillityUse()
    {
       SpawnEnemy();
    }

   
}
