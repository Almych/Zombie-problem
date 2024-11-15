using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//[CreateAssetMenu(fileName = "New AimItem", menuName = "ItemMenu/Items/Granades/DamageGranade")]
public class DamageGranade : Granade, IItemDamagable
{
    [SerializeField] protected float damage;
    private bool isHoldGranade = false;
    public void MakeDamage()
    {
       var colliders = Physics2D.CircleCastAll(transform.localPosition, radius, Vector2.zero);

        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].collider.GetComponent<Enemy>() != null)
            {
                colliders[i].collider.GetComponent<Enemy>().GetDamage(damage);
                gameObject.SetActive(false);
            }
        }
    }

    public override void Throw()
    {
        if (isHoldGranade)
        {
            isHoldGranade = false;
            ShootController.Instance.onItemUse.RemoveListener(MakeDamage);
            Debug.Log("Empty hand");
        }
        else
        {
            isHoldGranade = true;
            Debug.Log("Holding granade");
            ShootController.Instance.onItemUse.AddListener(MakeDamage);
        }
    }
}
