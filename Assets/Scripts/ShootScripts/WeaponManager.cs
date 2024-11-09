using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public WeaponManager(MelliGun melliGun = default, ColdWeapon cold = default)
    {
        if (cold != null)
        {
            ColdWeaponController coldController = new(cold);
        }else
        {
            MelliWeaponController melliWeaponController = new(melliGun);
        }
    }
}
