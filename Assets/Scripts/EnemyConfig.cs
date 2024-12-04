using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="Enemy/EnemyConfig", fileName ="New EnemyConfig")]
public class EnemyConfig : ScriptableObject
{
    [Header("Type of damage")]
    public Damage damageType;
    public float damage;
    public float maxHealth;
    public float speed;
}
