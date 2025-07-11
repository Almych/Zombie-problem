using System.Collections;
using UnityEngine;

public class RangeWeapon : IWeapon
{
    public int currAmount { get; private set; }
    public int maxAmount { get; private set; }
    public int totalAmount { get; private set; }
    public bool isReloading { get; private set; }
    public bool isBaseWeapon { get; private set; }
    public Sprite weaponSprite { get => config.weaponSprite; set => config.weaponSprite = value; }

    private readonly Transform shootPoint;
    private readonly RangeWeaponConfig config;
    private readonly MonoBehaviour coroutineRunner;

    public void AddAmount( int amount)
    {
        totalAmount += amount;
    }

    public RangeWeapon(RangeWeaponConfig weaponConfig, MonoBehaviour runner, Transform shootOrigin)
    {
        config = weaponConfig;
        shootPoint = shootOrigin;
        coroutineRunner = runner;

        maxAmount = config.maxBullets;
        currAmount = maxAmount;
        totalAmount = config.totalAmount;
        isBaseWeapon = weaponConfig.isBaseWeapon;

        ObjectPoolManager.CreateObjectPool(config.bulletType, config.maxBullets, bullet => bullet.InitConfig());
    }

    public void Execute()
    {
        if (isReloading || currAmount <= 0) return;

        var bullet = ObjectPoolManager.GetObjectFromPool(config.bulletType);
        var smoke = ObjectPoolManager.FindObjectByName<ParticleSystem>("Smoke");

        if (bullet != null && smoke != null)
        {
            bullet.transform.position = shootPoint.position;
            bullet.gameObject.SetActive(true);
            bullet.Activate(config._bulletConfig);

            smoke.transform.position = shootPoint.position;
            smoke.gameObject.SetActive(true);

            currAmount--;
            WeaponStateUI.Instance.UseBullet();

            if (currAmount <= 0)
                Reload();
        }
    }

    public void Reload()
    {
        if (isReloading || currAmount == maxAmount || totalAmount <= 0 && !isBaseWeapon) return;
        coroutineRunner.StartCoroutine(ReloadCoroutine());
    }

    private IEnumerator ReloadCoroutine()
    {
        isReloading = true;
        yield return new WaitForSeconds(config.reloadTime);

        int needed = maxAmount - currAmount;
        int reloaded;

        if (!isBaseWeapon)
        {
            reloaded = Mathf.Min(needed, totalAmount);
            totalAmount -= reloaded; 
        }
        else
        {
            reloaded = needed; 
        }

        currAmount += reloaded;
        WeaponStateUI.Instance.Reload();
        isReloading = false;
    }

}
