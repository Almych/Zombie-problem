
using UnityEngine;
using DG.Tweening; 

[CreateAssetMenu(fileName = "New DamageGrenade", menuName = "ItemMenu/Items/Grenades/DamageGrenade")]
public class ThrowableGrenade : Grenade
{
    [SerializeField] private float moveDuration = 1f;
    
    public override void Use()
    {
        GrenadeThrowManager.Instance.StartAiming(this);
    }

    public void ThrowAt(Vector3 targetPosition)
    {
        Vector3 spawnPos = GameObject.Find("Player").transform.position;

        var grenade = ObjectPoolManager.FindObject<GrenadeThrowable>();
        if (grenade != null)
        {
            grenade.transform.position = spawnPos;
            grenade.gameObject.SetActive(true);
            grenade.GetComponent<SpriteRenderer>().sprite = Sprite;

            Rigidbody2D rb = grenade.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.linearVelocity = Vector2.zero;
                rb.useFullKinematicContacts = true;
            }


            grenade.transform.DOMove(targetPosition, moveDuration)
                   .SetEase(Ease.Linear)
                   .OnComplete(() => OnGrenadeLanded(grenade.transform));
        }
    }


    private void OnGrenadeLanded(Transform grenadeTransform)
    {

        GrenadeThrowable grenade = grenadeTransform.GetComponent<GrenadeThrowable>();
        if (grenade != null)
        {
            grenade.SetGrenadeEffect((Enemy enemy) =>
            {
                damage.MakeDamage(enemy);
            }, grenadeParticle);
            grenade.ThrowEffect();
            grenade.Explode();
        }
    }

    public override void Initialize()
    {
        ObjectPoolManager.CreateObjectPool(grenadeParticle, 3);
    }
}
