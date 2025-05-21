using UnityEngine;

public class OnHealEvent
{
    public int healPoints { get; private set; }

    public OnHealEvent(int health)
    {
        healPoints = health;
    }
}
