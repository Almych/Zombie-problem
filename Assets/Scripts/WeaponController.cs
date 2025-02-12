using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEditor.SceneManagement;
using UnityEngine;

public abstract class WeaponController : MonoBehaviour
{
    public Sprite sprite;
    internal protected Weapon weapon;
    public abstract void Attack();
    public abstract IEnumerator Reload();

   
}

public class ColdWeaponController : WeaponController
{
    public ColdWeapon coldWeapon { get; private set; }
    private int currHitAmount;
    private bool isTired;
    private bool isEnemy = false;
    private Entity enemy;

    
    public void Initialize(ColdWeapon cold)
    {
        sprite = cold.weaponIcon;
        coldWeapon = cold;
        currHitAmount = coldWeapon.maxHitAmount;
        weapon = coldWeapon;
        isTired = false;
    }

    public override void Attack()
    {
        if (!isTired && isEnemy)
        {
            currHitAmount--;
            coldWeapon.damageType.MakeDamage(enemy);
        }
        else
        {
            StartCoroutine(Reload());
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<Entity>() != null)
        {
            isEnemy = true;
           enemy = collision.GetComponent<Entity>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Entity>() != null)
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

   
}

public class MelliWeaponController : WeaponController
{
    private MelliWeapon melliGun;
    private int currBulletAmount = 0;
    private bool hasAmmo = false;
    private bool isReloading = false;
    public void Initialize(MelliWeapon melli)
    {
        melliGun = melli;
        sprite = melli.weaponIcon;
        weapon = melliGun;
        CheckBullets();
    }


    public override void Attack()
    {

        if (hasAmmo)
        {
            
            BulletBehaivior bullet = ObjectPoolManager.FindObject<BulletBehaivior>();
            if (bullet != null)
            {
                bullet.gameObject.SetActive(true);
                bullet.DamageOfBullet(melliGun.damageType);
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
            {
                if (!isReloading)
                {
                    isReloading = true;
                    StartCoroutine(Reload());
                }
            }
        }
       
    }

    public override IEnumerator Reload()
    {
        yield return new WaitForSeconds(melliGun.reloadTime);
        CheckBullets();
        isReloading = false;
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
        else
        {
            return;
        }
    }

    
}
