
using UnityEngine;
using DG.Tweening; 

[CreateAssetMenu(fileName = "New DamageGrenade", menuName = "ItemMenu/Items/Grenades/DamageGrenade")]
public class ThrowableGrenade : Grenade
{
    [SerializeField] private float moveDuration = 1f;
    [SerializeField, Range(1, 5)] private int grenadeParticleSpawnAmount = 3;
    
    public override void Use()
    {
        GrenadeThrowManager.Instance.StartAiming(this);
    }

    public void ThrowAt(Vector3 targetPosition)
    {
        Vector3 spawnPos = PlayerController.Instance.transform.position;

        var grenade = ObjectPoolManager.FindObjectByName<GrenadeThrowable>("Grenade");
        if (grenade != null)
        {
            grenade.transform.position = spawnPos;
            grenade.gameObject.SetActive(true);
            grenade.SetGrenadeEffect(damage, grenadeParticle, Sprite);
            grenade.Throw(targetPosition, moveDuration);

        }
    }


   
    public override void Initialize()
    {
        ObjectPoolManager.CreateObjectPool(grenadeParticle, grenadeParticleSpawnAmount);
    }
}
