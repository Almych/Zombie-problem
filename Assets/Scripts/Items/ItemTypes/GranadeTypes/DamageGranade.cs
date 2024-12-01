using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;

public class DamageGranade : Granade
{

    [SerializeField] protected float damage;
    private bool isHoldGranade = false;

   
    private void Makedamage(Vector2 cord)
    {
        var granade = Instantiate(gameObject, cord, Quaternion.identity);
        var colliders = Physics2D.CircleCastAll(granade.transform.position, radius, Vector2.zero);

        for (int i = 0; i < colliders.Length; i++)
        {
            Debug.Log(colliders[i].collider.name);
            if (colliders[i].collider.GetComponent<Enemy>() != null)
            {
                colliders[i].collider.GetComponent<Enemy>().GetDamage(damage);
            }
        }
        granade.SetActive(false);
        isHoldGranade = false;
    }

    public override void Throw()
    {
        OnPointerClicked(Makedamage);
    }

    //void OnDrawGizmos()
    //{
    //    Debug.Log("drawed gizmos");
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawWireSphere(transform.position, radius);
    //}
}

