using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnStateMachine 
{
    public SpawnNoneState spawnNoneState { get; private set; }
    public SpawnPreWaveState spawnPreWaveState { get; private set; }
    public SpawnWaveState spawnWaveState { get; private set; }
    public SpawnState currentState { get; private set; }
    private MonoBehaviour _mono;
    public SpawnStateMachine(MonoBehaviour mono)
    {
        spawnNoneState = new SpawnNoneState();
        spawnWaveState = new SpawnWaveState();
        spawnPreWaveState = new SpawnPreWaveState(mono);
        currentState = spawnNoneState;
    }

    public void SwitchState(SpawnState newState, List<EnemyData> enemies)
    {
        currentState = newState;
        currentState.Enter(enemies);
    }
}
