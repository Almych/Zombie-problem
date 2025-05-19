using UnityEngine;


public abstract class DeathProviderConfig : ScriptableObject
{
    protected DeathProvider deathProvider;

    public virtual DeathProvider SetDeath(Enemy enemy)
    {
        return deathProvider;
    }
}
