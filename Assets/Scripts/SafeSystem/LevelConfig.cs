using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="New Level Config", menuName ="LevelConfig")]
public class LevelConfig : ScriptableObject
{
   public WaveConfig WavesConfig;
   public CollectableConfig CollectablesConfig;
}
