using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

public abstract class WeaponController : MonoBehaviour
{
    public bool canCall;
    public abstract void Attack();
    public abstract IEnumerator Reload();

    public abstract Sprite TakeWeapon();
}

public class ColdWeaponController : WeaponController
{
    private ColdWeapon coldWeapon;
    private int currHitAmount;
    private bool isTired;
    private bool isEnemy = false;
    private Enemy enemy;
    public void Initialize(ColdWeapon cold)
    {
        canCall = true;
        coldWeapon = cold;
        currHitAmount = coldWeapon.maxHitAmount;
        isTired = false;
    }

    public override void Attack()
    {
        if (!isTired && isEnemy)
        {
            currHitAmount--;
            enemy.GetComponent<SpriteRenderer>().color = Color.red;
            enemy.GetDamage(coldWeapon.damage);
        }
        else
        {
            canCall = false;
            StartCoroutine(Reload());
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<Enemy>() != null)
        {
            Debug.Log("enemy");
            isEnemy = true;
           enemy = collision.GetComponent<Enemy>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Enemy>() != null)
        {
            Debug.Log("no enemy");
            isEnemy = false;
            enemy = null;
        }
    }

    public override IEnumerator Reload()
    {
        yield return new WaitForSeconds(coldWeapon.hitTime);
        currHitAmount = coldWeapon.maxHitAmount;
        isTired = false;
        canCall = true;
        Debug.Log("Cold Weapon reloaded!");
    }

    public override Sprite TakeWeapon()
    {
        return coldWeapon.weaponIcon;
    }
}

public class MelliWeaponController : WeaponController
{
    private MelliGun melliGun;
    private int currBulletAmount = 0;
    private bool hasAmmo = false;

    public void Initialize(MelliGun melli)
    {
        melliGun = melli;
        BulletPool.Instance.BulletInitialize(melliGun.bulletSprite);
        CheckBullets();
    }


    public override void Attack()
    {
        if (hasAmmo)
        {
            var bullet = BulletPool.Instance.GetPoolObject();
            if (bullet != null)
            {
                bullet.DamageOFBullet(melliGun.damage);
                bullet.transform.position = transform.position;
                bullet.Activate();
                currBulletAmount--;
                if (currBulletAmount <= 0)
                {
                    hasAmmo = false;
                }
            }
        }
        else
        {
            if (melliGun.totalBulletAmount != 0)
            StartCoroutine(Reload());
            else
            {
                Debug.Log("run out of bullets");
                canCall = false;
            }
        }
       
    }

    public override IEnumerator Reload()
    {
        canCall = false;
        yield return new WaitForSeconds(melliGun.reloadTime);
        CheckBullets(); 
    }
    private void CheckBullets()
    {
        if (melliGun.totalBulletAmount >= melliGun.maxBullets)
        {
            currBulletAmount = melliGun.maxBullets;
            melliGun.totalBulletAmount -= melliGun.maxBullets;
            hasAmmo = true;

        }
        else if (melliGun.totalBulletAmount > 0 && melliGun.totalBulletAmount < melliGun.maxBullets)
        {
            currBulletAmount = melliGun.totalBulletAmount;
            melliGun.totalBulletAmount = 0;
            hasAmmo = true;
        }
        canCall = true;
    }
    public override Sprite TakeWeapon()
    {
        return melliGun.weaponIcon;
    }
}
