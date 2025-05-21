
using UnityEngine;
using DG.Tweening; 

[CreateAssetMenu(fileName = "New DamageGrenade", menuName = "ItemMenu/Items/Grenades/DamageGrenade")]
public class DamageGrenade : Grenade
{
    [SerializeField] protected Damage damageType;
    [SerializeField] private float moveDuration = 1f; 

    public override void Use()
    {
        GrenadeThrowManager.Instance.StartAiming(this);
    }

    public void ThrowAt(Vector3 targetPosition)
    {
        Debug.Log("throwed!");
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
        Debug.Log("Grenade reached target");

        GrenadeThrowable grenade = grenadeTransform.GetComponent<GrenadeThrowable>();
        if (grenade != null)
        {
            // Set the explosion effect
            grenade.SetGrenadeEffect((Enemy enemy) =>
            {
                enemy.TakeDamage(damageType); // You should implement this
            });

            grenade.Explode();
        }
    }

}
