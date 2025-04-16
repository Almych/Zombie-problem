using UnityEngine;

public class ZigZagMove : MoveProvider
{
    private float _frequency = 5f; // Speed of the zigzag oscillation
    private float _amplitude = 1f; // Width of the zigzag
    private float _time;

    public ZigZagMove(Transform transform, Rigidbody2D rb, float speed, IMoveAbility moveAbility, int moveAbilityTicks, float sidesTime, float frequence) : base(transform, rb, speed, moveAbility, moveAbilityTicks)
    {
        _amplitude = sidesTime;
        _frequency = frequence;
    }

    public override void Move()
    {
        _time += Time.deltaTime;

        // Move forward (e.g., to the left) with side-to-side sine motion
        Vector2 forward = Vector2.left * _speed;
        Vector2 side = Vector2.up * Mathf.Sin(_time * _frequency) * _amplitude;

        _rb.velocity = forward + side;
    }
}
