using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class ShootController : MonoBehaviour
{
    public static ShootController Instance;
    [SerializeField] private Inventory inventory;
    public static event Action OnShootAnimate;
    public static WeaponController controller;
    private WeaponController[] weaponControllers;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
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
        else if (weapon is MelliWeapon melli)
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

    public void ChangeWeapon(ref WeaponController currentController) 
    {

        for (int i = 0; i < weaponControllers.Length; i++)
        {
            if (currentController != weaponControllers[i])
            {
                currentController.enabled = false;
                weaponControllers[i].enabled = true;
                currentController = weaponControllers[i];
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
