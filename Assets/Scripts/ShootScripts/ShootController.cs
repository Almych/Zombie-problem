using System;
using System.Collections;
using UnityEngine;

public class ShootController : MonoBehaviour
{
    public static event Action OnShootAnimate;
    public Weapon weapon;
    private WeaponManager weaponManager;
    //public static ShootController instance;
    //private int maxBullet;
    //private float reloadTime;
    //public float damage { get; private set; }
    //private bool isReload;
    //private int currBullet;

    //private void Awake()
    //{
    //    if (instance == null)
    //    {
    //        instance = this;
    //    }
    //}
    private void Start()
    {
        //maxBullet = weapon.bulletMax;
        //reloadTime = weapon.realodTime;
        //damage = weapon.damage;
        //transform.parent.GetComponent<SpriteRenderer>().sprite = weapon.weaponSprite;
        //isReload = false;
        //currBullet = maxBullet;
        weaponManager = new WeaponManager(weapon, transform.parent.GetComponent<SpriteRenderer>().sprite);      
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (weaponManager!= null)
            {
                weaponManager.currentWeaponController.Attack();
            }
        }
    }

    //private void Fire()
    //{
    //    if (currBullet > 0)
    //    {
    //        BulletBehaivior bullet = BulletPool.Instance.GetPoolObject();

    //        if (bullet != null)
    //        {
    //            //.GetComponent<SpriteRenderer>().sprite = weapon.bulletSprite;
    //            bullet.transform.position = transform.position;
    //            bullet.gameObject.SetActive(true);
    //            bullet.Activate();
    //            currBullet--;
    //        }
    //    }
    //    else
    //    {
    //        StartCoroutine(Reload());
    //    }

    //}

    //private IEnumerator Reload()
    //{
    //    isReload=true;
    //    yield return new WaitForSeconds(reloadTime);
    //    currBullet = maxBullet;
    //    isReload=false;
    //}
}
