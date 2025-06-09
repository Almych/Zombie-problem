
public class WeaponTake : Takable
{
    private WeaponConfig weaponConfig;
   
    public override void OnCollect()
    {
        EventBus.Publish(new OnCollectEvent(weaponConfig));
        base.OnCollect();
    }

    public void SetCollectable(WeaponConfig weapon)
    {
        weaponConfig = weapon;
        render.sprite = weapon.weaponSprite;
    }
}