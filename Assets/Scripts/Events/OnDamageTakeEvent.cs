using UnityEngine;

public class OnDamageTakeEvent
{
    public int damage { get; private set; }

    public OnDamageTakeEvent(int takenDamage)
    {
        damage = takenDamage;
    }
}
