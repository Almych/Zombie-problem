using UnityEngine;
public abstract class Grenade : Item
{
    [SerializeField] protected Damage damage;
    [SerializeField] protected ParticleSystem grenadeParticle;
}
