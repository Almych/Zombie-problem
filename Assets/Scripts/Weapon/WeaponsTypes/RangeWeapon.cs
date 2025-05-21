using System.Collections;
using UnityEngine;

public class RangeWeapon : IWeapon
{
    public int currAmount { get; private set; }
    public int maxAmount { get; private set; }
    public bool isReloading { get; private set; }
    private Transform _shootPoint;
    private RangeWeaponConfig _rangeWeaponConfig;
    private MonoBehaviour _coroutineRunner;
    public RangeWeapon(RangeWeaponConfig weaponConfig, MonoBehaviour runner, Transform transform)
    {
        _rangeWeaponConfig = weaponConfig;
        _shootPoint = transform;
        maxAmount = weaponConfig.maxBullets;
        currAmount = weaponConfig.maxBullets;
        _coroutineRunner = runner;
        ObjectPoolManager.CreateObjectPool(_rangeWeaponConfig.bulletType, 5, bullet => bullet.InitConfig());
    }


    public void Execute()
    {
        if (isReloading)
            return;
        BulletBehaivior bullet = ObjectPoolManager.GetObjectFromPool(_rangeWeaponConfig.bulletType);
        ParticleSystem shootParticle = ObjectPoolManager.FindObjectByName<ParticleSystem>("ShootParticle");
        if (bullet != null && shootParticle != null)
        {
            bullet.gameObject.SetActive(true);
            shootParticle.gameObject.SetActive(true);
            shootParticle.transform.position = _shootPoint.position;
            bullet.transform.position = _shootPoint.position;
            bullet.Activate(_rangeWeaponConfig._bulletConfig);
            currAmount--;
            if (currAmount <= 0)
                Reload();
        }
    }

    public void Reload()
    {
        if (isReloading || currAmount == maxAmount)
        {
            return;
        }

        _coroutineRunner.StartCoroutine(ReloadCoroutine());
    }

    private IEnumerator ReloadCoroutine()
    {
        isReloading = true;
        yield return new WaitForSeconds(_rangeWeaponConfig.reloadTime);
        currAmount = maxAmount;
        isReloading = false;
    }

}
