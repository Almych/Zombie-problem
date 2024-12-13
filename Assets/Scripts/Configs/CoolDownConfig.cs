using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New CoolDownConfig", menuName = "EnemyConfigs/CoolDownConfig")]
public class CoolDownConfig : ScriptableObject
{
    [Range(1, 5)] public int coolDown;
}
