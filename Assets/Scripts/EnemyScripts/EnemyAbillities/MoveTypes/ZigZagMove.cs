using System;
using UnityEngine;

public class ZigZagMove : MoveProvider
{
    private float _frequency = 5f; // Speed of the zigzag oscillation
    private float _amplitude = 1f; // Width of the zigzag
    private float _time;
    private float _phaseOffset; // _phase offset gives random value between up 0 and down 3.14
    public ZigZagMove(Enemy enemy, float amplitude, float frequence) : base(enemy)
    {
        _amplitude = amplitude;
        _frequency = frequence;
        _phaseOffset = UnityEngine.Random.value > 0.5f ? 0f : Mathf.PI;
    }

    public override void Move()
    {
        _time += Time.deltaTime;

        Vector2 forward = Vector2.left * _enemy.GetCurrentSpeed();
        Vector2 side = Vector2.up * Mathf.Sin(_time * _frequency + _phaseOffset) * _amplitude;

        _enemy.rb.linearVelocity = forward + side;
    }
}
