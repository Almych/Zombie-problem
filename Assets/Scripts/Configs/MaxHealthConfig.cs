using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New MaxHealthConfig", menuName = "EnemyConfigs/MaxHealthConfig")]
public class MaxHealthConfig : ScriptableObject
{
    [Range(1,100)]public int maxHealth;
}
