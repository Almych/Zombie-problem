using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnStateMachine 
{
    public SpawnNoneState spawnNoneState { get; private set; }
    public SpawnPreWaveState spawnPreWaveState { get; private set; }
    public SpawnWaveState spawnWaveState { get; private set; }
    public SpawnState currentState { get; private set; }
    public SpawnStateMachine(MonoBehaviour mono)
    {
        spawnNoneState = new SpawnNoneState(mono);
        spawnWaveState = new SpawnWaveState(mono);
        spawnPreWaveState = new SpawnPreWaveState(mono);
        currentState = spawnNoneState;
    }

    public void SwitchState(SpawnState newState, EnemyData[] enemies)
    {
        currentState = newState;
        currentState.Enter(enemies);
    }
}
