using UnityEngine;

public abstract class DeathProvider : IDieStrategy
{
    protected GameObject _entity;
    public DeathProvider(GameObject entity)
    {
        _entity = entity;
    }
    public virtual void Die()
    {
        _entity.SetActive(false);
    }
}
