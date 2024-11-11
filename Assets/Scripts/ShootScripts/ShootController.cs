using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class ShootController : MonoBehaviour
{
    public static event Action OnShootAnimate;
    public Weapon weapon;
    private WeaponController controller;

    void Start()
    {
        controller = GetWeaponController(weapon);
        GetComponent<SpriteRenderer>().sprite = controller.TakeWeapon();
    }

    private WeaponController GetWeaponController(Weapon weapon)
    {
        if (weapon is ColdWeapon cold)
        {
            ColdWeaponController coldWeaponController = gameObject.AddComponent<ColdWeaponController>();
            coldWeaponController.Initialize(cold);
            return coldWeaponController;
        }
        else if (weapon is MelliGun melli)
        {
            MelliWeaponController melliWeaponController = gameObject.AddComponent<MelliWeaponController>();
            melliWeaponController.Initialize(melli);
            return melliWeaponController;
        }
        else
        {
            return null;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && controller.canCall)
        {
            Debug.Log("Called");
            controller.Attack();
            //OnShootAnimate?.Invoke();
        }
    }

   

}
