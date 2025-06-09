using UnityEngine;

[CreateAssetMenu(fileName = "New Range Weapon", menuName = "Weapon/Range")]
public class RangeWeaponConfig : WeaponConfig
{
    [SerializeField] private Sprite _weaponSprite;
    public BulletBehaivior bulletType;
    public PlayerBulletConfig _bulletConfig;
    public float reloadTime;
    public int maxBullets;
    public int totalAmount;
    public bool isBaseWeapon;
    public override Damage damage { get => _bulletConfig.damage; set => _bulletConfig.damage = value; }
    public override Sprite weaponSprite { get => _weaponSprite; set => _weaponSprite = value; }
}
