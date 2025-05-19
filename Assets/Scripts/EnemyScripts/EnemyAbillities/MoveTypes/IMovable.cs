using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMoveStrategy  
{
    void Move();

    void StopMove();
}

public interface ISpeedProvider
{
    void ReduceSpeed(float speedProcents = 0.1f);
    void IncreaseSpeed(float speedProcents = 0.1f);

    void ResetSpeed();
}