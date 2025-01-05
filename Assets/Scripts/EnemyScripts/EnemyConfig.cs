using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="Enemy/EnemyConfig", fileName ="New EnemyConfig")]
public class EnemyConfig : ScriptableObject
{
    [Range(1,20)] public float maxHealth;
    [Range(1,10)] public float speed;
    [Range(0,10)] public float damage;
    [Range(1, 5)] public float attackCoolDown;
    [Range(0, 9)] public float attackRange;
    public LayerMask barrier;
}
