using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeStateAbility : IMoveAbility
{
    private Enemy _enemy;
    private int _changeState;
    public ChangeStateAbility(Enemy enemy, int changeState)
    {
        _enemy = enemy;
        _changeState = changeState;
    }
    public void OnMove()
    {
        if (_changeState == 0)
            _enemy.stateMachine?.TryTranslate<RunState>();
        else if(_changeState == 1)
            _enemy.stateMachine?.TryTranslate<AttackState>();
        else
            _enemy.stateMachine?.TryTranslate<DieState>();
    }
}
