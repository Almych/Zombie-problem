using System.Collections;
using UnityEngine;

public class RangeWeapon : IWeapon
{
    private Transform _shootPoint;
    private RangeWeaponConfig _rangeWeaponConfig;
    private int currAmount;
    private MonoBehaviour _coroutineRunner;
    private bool isReloading = false;
    public RangeWeapon(RangeWeaponConfig weaponConfig, MonoBehaviour runner, Transform transform)
    {
        _rangeWeaponConfig = weaponConfig;
        _shootPoint = transform;
        currAmount = weaponConfig.maxBullets;
        _coroutineRunner = runner;
        ObjectPoolManager.CreateObjectPool(_rangeWeaponConfig.bulletType, 5, bullet => bullet.SetConfig(_rangeWeaponConfig._bulletConfig));
    }


    public void Execute()
    {
        if (isReloading)
            return;
        BulletBehaivior bullet = ObjectPoolManager.GetObjectFromPool(_rangeWeaponConfig.bulletType);
        if (bullet != null)
        {
            bullet.gameObject.SetActive(true);
            bullet.transform.position = _shootPoint.position;
            bullet.Activate();
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
