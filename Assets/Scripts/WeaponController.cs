using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class WeaponController : MonoBehaviour
{
    public abstract void  Attack();

    public abstract IEnumerator Reload();

   
}

public class ColdWeaponController : WeaponController
{
    private ColdWeapon coldWeapon;
    private int currHitAmount;
    private bool isTired;

   
    public ColdWeaponController(ColdWeapon cold)
    {
        coldWeapon = cold;
        currHitAmount = coldWeapon.maxHitAmount;
        isTired = false;
    }

    

    public override void Attack()
    {
        if (!isTired)
        {
            currHitAmount--;
        }
        else
        {
            StartCoroutine(Reload());
        }
    }

    public override IEnumerator Reload()
    {
        yield return new WaitForSeconds(coldWeapon.hitTime);
        currHitAmount = coldWeapon.maxHitAmount;
        isTired = false;
    }
}

public class MelliWeaponController : WeaponController
{
    private MelliGun melliGun;
    private bool hasAmmo;
    private int currBulletAmount;



    public MelliWeaponController(MelliGun melli, Sprite weapon)
    {
        melliGun = melli;
        weapon = melli.weaponIcon;
        if (melliGun.totalBulletAmount > 0)
        currBulletAmount = melliGun.maxBullets;
    }

    public override void Attack()
    {
        var bullet = BulletPool.Instance.GetPoolObject();
        bullet.DamageOFBullet(melliGun.damage);
        if (bullet != null && hasAmmo)
        {
            bullet.Activate();
            currBulletAmount--;
            melliGun.totalBulletAmount--;
            if (currBulletAmount <= 0)
            {
                hasAmmo = false;
            }
        }
        else
        {
            StartCoroutine(Reload());
        }
    }

    public override IEnumerator Reload()
    {
        yield return new WaitForSeconds(melliGun.reloadTime);
        if (melliGun.totalBulletAmount <=0)
        {
            currBulletAmount = melliGun.maxBullets;
            hasAmmo = true;
        }
        else
        {
            Debug.Log("Run out of bullet");
        }
    }
}