using System.Collections;
using UnityEngine;

public class ShootController : MonoBehaviour
{
    [SerializeField] private Weapon weapon;
    private int maxBullet;
    private float reloadTime;
    private float damage;
    private bool isReload;
    private int currBullet;

    private void Start()
    {
        maxBullet = weapon.bulletMax;
        reloadTime = weapon.realodTime;
        damage = weapon.damage;
        transform.parent.GetComponent<SpriteRenderer>().sprite = weapon.iconOfWeapon;
        isReload = false;
        currBullet = maxBullet;
    }
    void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isReload)
        {
            Fire();
        }
    }

    private void Fire()
    {
        if (currBullet > 0)
        {
            GameObject bullet = BulletPool.Instance.GetPoolObject();

            if (bullet != null)
            {
                bullet.transform.position = transform.position;
                bullet.SetActive(true);
                bullet.GetComponent<BulletBehaivior>().Activate();
                currBullet--;
            }
        }
        else
        {
            StartCoroutine(Reload());
        }
        
    }

    private IEnumerator Reload()
    {
        isReload=true;
        yield return new WaitForSeconds(reloadTime);
        currBullet = maxBullet;
        isReload=false;
    }
}
