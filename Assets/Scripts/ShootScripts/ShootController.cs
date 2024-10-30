using System;
using System.Collections;
using UnityEngine;

public class ShootController : MonoBehaviour
{
    public static event Action OnShootAnimate;
    public static ShootController instance;
    [SerializeField] private Weapon weapon;
    private int maxBullet;
    private float reloadTime;
    public float damage { get; private set; }
    private bool isReload;
    private int currBullet;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    private void Start()
    {
        maxBullet = weapon.bulletMax;
        reloadTime = weapon.realodTime;
        damage = weapon.damage;
        transform.parent.GetComponent<SpriteRenderer>().sprite = weapon.iconOfWeapon;
        isReload = false;
        currBullet = maxBullet;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isReload)
        {
            Fire();
            OnShootAnimate?.Invoke();
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
