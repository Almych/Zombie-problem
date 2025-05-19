using UnityEngine;

[CreateAssetMenu(fileName = "DefaultDeathConfig", menuName = "DeathProviderConfig/DefaultDeathConfig")]
public class DefaultDeathConfig : DeathProviderConfig
{
    public override DeathProvider SetDeath(Enemy enemy)
    {
        deathProvider = new DefaultDeath(enemy.gameObject);
        return deathProvider;
    }
}
