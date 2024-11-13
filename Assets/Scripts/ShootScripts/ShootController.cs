using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class ShootController : MonoBehaviour
{
    [SerializeField] private Inventory inventory;
    public static event Action OnShootAnimate;
    private WeaponController controller;
    private WeaponController[] weaponControllers ;
    void Start()
    {
        weaponControllers = new WeaponController[inventory.weaponSlots.Length];
        for (int i = 0; i < weaponControllers.Length; i++)
        {
            weaponControllers[i] = GetWeaponController(inventory.weaponSlots[i]);
            weaponControllers[i].enabled = false;
        }
        controller = weaponControllers[0];
        controller.enabled = true;
        GetComponent<SpriteRenderer>().sprite = controller.sprite;
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

    public void ChangeWeapon(ref WeaponController currentWeapon)
    {

        for (int i = 0; i < weaponControllers.Length; i++)
        {
            if (currentWeapon != weaponControllers[i])
            {
                currentWeapon.enabled = false;
                weaponControllers[i].enabled = true;
                currentWeapon = weaponControllers[i];
                GetComponent<SpriteRenderer>().sprite = controller.sprite;
                break;
            }
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            controller.Attack();
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            ChangeWeapon(ref controller);
        }
    }

   

}
