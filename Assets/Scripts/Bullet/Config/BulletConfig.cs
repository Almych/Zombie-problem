using UnityEngine;
[CreateAssetMenu(fileName = "New Bullet Config", menuName = "BulletConfig")]
public class BulletConfig : ScriptableObject
{
    public float speed;
    public Damage damage;
    [Range(2,4)]public float bulletLifeTime;
    public Sprite bulletSprite;
}
