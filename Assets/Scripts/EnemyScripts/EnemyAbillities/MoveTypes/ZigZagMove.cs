using UnityEngine;

public class ZigZagMove : MoveProvider
{
    private float _frequency = 5f; // Speed of the zigzag oscillation
    private float _amplitude = 1f; // Width of the zigzag
    private float _time;
    private float _phaseOffset; // _phase offset gives random value between up 0 and down 3.14
    public ZigZagMove(Transform transform, Rigidbody2D rb, float speed, IMoveAbility moveAbility, int moveAbilityTicks, float sidesTime, float frequence) : base(transform, rb, speed, moveAbility, moveAbilityTicks)
    {
        _amplitude = sidesTime;
        _frequency = frequence;
        _phaseOffset = Random.value > 0.5f ? 0f : Mathf.PI;
    }

    public override void Move()
    {
        _time += Time.deltaTime;

        Vector2 forward = Vector2.left * _speed;
        Vector2 side = Vector2.up * Mathf.Sin(_time * _frequency + _phaseOffset) * _amplitude;

        _rb.velocity = forward + side;
    }
}
