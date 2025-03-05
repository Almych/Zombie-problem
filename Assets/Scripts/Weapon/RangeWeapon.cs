using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeWeapon : IWeapon
{
    private Vector3 _shootPoint;
    private RangeWeaponConfig _rangeWeaponConfig;
    private int currAmount;
    private MonoBehaviour _coroutineRunner;
    private bool isReloading = false;
    public RangeWeapon(RangeWeaponConfig weaponConfig, MonoBehaviour runner)
    {
        _rangeWeaponConfig = weaponConfig;
        currAmount = weaponConfig.maxBullets;
        _coroutineRunner = runner;
    }

    public void SetShootPoint(Vector3 shootPoint)
    {
        _shootPoint = shootPoint;
    }

    public void Execute()
    {
        if (isReloading)
            return;
        BulletBehaivior bullet = ObjectPoolManager.FindObject<BulletBehaivior>();
        if (bullet != null)
        {
            bullet.gameObject.SetActive(true);
            bullet.Activate(_rangeWeaponConfig.bulletSprite, _shootPoint, _rangeWeaponConfig.damage, _rangeWeaponConfig.bulletSpeed);
            currAmount--;
            if (currAmount <= 0)
                _coroutineRunner.StartCoroutine(Reload());
        }
    }

    public IEnumerator Reload()
    {
        isReloading = true;
        yield return new WaitForSeconds(_rangeWeaponConfig.reloadTime);
        currAmount = _rangeWeaponConfig.maxBullets;
        isReloading = false;
    }
}
