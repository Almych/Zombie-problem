using UnityEngine;
[CreateAssetMenu(fileName = "New Playerbullet Config", menuName = "BulletConfig/PlayerBulletConfig")]
public class PlayerBulletConfig : BaseBulletConfig
{
    public Damage damage;
    [Range(2, 4)] public float bulletLifeTime;
}
