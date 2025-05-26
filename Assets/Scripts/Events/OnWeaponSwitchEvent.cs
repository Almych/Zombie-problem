using UnityEngine;

public class OnWeaponSwitchEvent
{
    public IWeapon Weapon {  get; private set; }
    public OnWeaponSwitchEvent(IWeapon weapon)
    {
        Weapon = weapon;
    }
}
