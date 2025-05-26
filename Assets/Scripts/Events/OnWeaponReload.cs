using UnityEngine;

public class OnWeaponReloadEvent
{
    public RangeWeapon RangeWeapon {  get; private set; }
    public OnWeaponReloadEvent(RangeWeapon rangeWeapon)
    {
        RangeWeapon = rangeWeapon;
    }
}
