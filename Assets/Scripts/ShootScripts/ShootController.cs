using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ShootController : MonoBehaviour
{
    [SerializeField] private PlayInventory inventory;
    public IWeapon[] weaponSlots = new IWeapon[2];
    private int activeWeaponIndex = 0;

    void Start()
    {
        Init();
    }

    private void Init()
    {
        if (inventory != null)
        {
            EquipWeapon(inventory.weaponSlots);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            if (weaponSlots[activeWeaponIndex] is RangeWeapon rangeWeapon)
            {
                rangeWeapon.SetShootPoint(transform.position);
            }
            weaponSlots[activeWeaponIndex]?.Execute();
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            SwitchWeapon();
        }
    }

    public void EquipWeapon(IWeaponConfig[] weaponConfigs)
    {
        if (weaponConfigs.Length == 0) return;

        for (int i = 0; i < weaponSlots.Length; i++)
        {
            if (i >= weaponConfigs.Length) break;

            if (weaponConfigs[i] is MeleeWeaponConfig meleeWeaponConfig)
            {
                weaponSlots[i] = new MeleeWeapon(meleeWeaponConfig);
            }
            else if (weaponConfigs[i] is RangeWeaponConfig rangeWeaponConfig)
            {
                weaponSlots[i] = new RangeWeapon(rangeWeaponConfig, this);
            }
        }

        SwitchWeapon();
    }

    private void SwitchWeapon()
    {
        activeWeaponIndex = (activeWeaponIndex + 1) % weaponSlots.Length;
        GetComponent<SpriteRenderer>().sprite = inventory.weaponSlots[activeWeaponIndex].weaponSprite;
    }
}
