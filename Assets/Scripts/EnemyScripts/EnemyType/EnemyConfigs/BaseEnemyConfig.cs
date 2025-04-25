using UnityEngine;


public abstract class BaseEnemyConfig : ScriptableObject
{
    public float speed;
    public EnemyUniqDefense uniqDefense;
    public float maxHealth;
    public AttackTypeConfig attackType;
    public MoveTypeConfig moveType;
}

