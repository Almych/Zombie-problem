using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New SpeedConfig", menuName = "EnemyConfigs/SpeedConfig")]
public class SpeedConfig : ScriptableObject
{
    [Range(1, 10)] public float speed;
}
