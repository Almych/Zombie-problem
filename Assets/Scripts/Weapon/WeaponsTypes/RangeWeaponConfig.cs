using UnityEngine;

[CreateAssetMenu(fileName = "New Range Weapon", menuName = "Weapon/Range")]
public class RangeWeaponConfig : WeaponConfig
{
    [SerializeField] private Sprite _weaponSprite;
    public BulletBehaivior bulletType;
    public BulletConfig _bulletConfig;
    public float reloadTime;
    public int maxBullets;

   
    public override Damage damage { get => _bulletConfig.damage; set => _bulletConfig.damage = value; }
    public override Sprite weaponSprite { get => _weaponSprite; set => _weaponSprite = value; }
}
