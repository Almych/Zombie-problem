using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager 
{
    public WeaponController currentWeaponController { get; private set; }
    public WeaponManager(Weapon weapon, Sprite hand)
    {
        if (weapon is ColdWeapon coldWeapon)
        {
            currentWeaponController = new ColdWeaponController(coldWeapon);
        }
        else if (weapon is MelliGun melliGun)
        {
            currentWeaponController = new MelliWeaponController(melliGun, hand);
        }
        else
        {
            Debug.LogError("Weapon type is not recognized!");
        }
    }
    
    
}
