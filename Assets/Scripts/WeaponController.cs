using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

public abstract class WeaponController : MonoBehaviour
{
    public Sprite sprite;
    public Weapon weapon { get; private set; }
    public abstract void Attack();
    public abstract IEnumerator Reload();

    public abstract Weapon GetWeapon();
}

public class ColdWeaponController : WeaponController
{
    public ColdWeapon coldWeapon { get; private set; }
    private int currHitAmount;
    private bool isTired;
    private bool isEnemy = false;
    private Enemy enemy;
    public void Initialize(ColdWeapon cold)
    {
        sprite = cold.weaponIcon;
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
            StartCoroutine(Reload());
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<Enemy>() != null)
        {
            isEnemy = true;
           enemy = collision.GetComponent<Enemy>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Enemy>() != null)
        {
            isEnemy = false;
            enemy = null;
        }
    }

    public override IEnumerator Reload()
    {
        yield return new WaitForSeconds(coldWeapon.hitTime);
        currHitAmount = coldWeapon.maxHitAmount;
        isTired = false;
    }

    public override Weapon GetWeapon()
    {
        return coldWeapon;
    }
}

public class MelliWeaponController : WeaponController
{
    private MelliWeapon melliGun;
    private int currBulletAmount = 0;
    private bool hasAmmo = false;

    public void Initialize(MelliWeapon melli)
    {
        melliGun = melli;
        sprite = melli.weaponIcon;
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
                bullet.Activate(melliGun.bulletSprite);
                currBulletAmount--;
                melliGun.totalBullets--;
                melliGun.TotalAmount--;
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
            }
        }
       
    }

    public override IEnumerator Reload()
    {
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
        };
    }

    public override Weapon GetWeapon()
    {
       return melliGun;
    }
}
