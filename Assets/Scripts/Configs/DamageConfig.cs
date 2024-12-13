using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New DamageConfig", menuName = "EnemyConfigs/DamageConfig")]
public class DamageConfig : ScriptableObject
{
   [Range(1,25)] public float damage;
}

