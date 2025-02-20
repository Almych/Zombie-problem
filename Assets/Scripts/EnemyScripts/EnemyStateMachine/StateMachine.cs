using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class StateMachine 
{
    public State currentState {  get; private set; }
    private Dictionary<Type, State> knownStates = new Dictionary<Type, State>();

    public void AddState(State newState)
    {
        if (newState == null || knownStates.ContainsKey(newState.GetType()))
            return;

        knownStates[newState.GetType()] = newState;
    }

    public void SwitchState<T>() where T : State
    {
        if (!knownStates.TryGetValue(typeof(T), out State newState))
        {
            Debug.LogWarning($"State of type {typeof(T)} not found!");
            return;
        }

        currentState?.Exit();
        currentState = newState;
        currentState?.Enter();
    }
}
