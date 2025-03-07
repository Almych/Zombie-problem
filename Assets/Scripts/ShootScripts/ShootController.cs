using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ShootController : MonoBehaviour
{
    [SerializeField] private PlayInventory inventory;
    public IWeapon[] weaponSlots = new IWeapon[2];
    private int activeWeaponIndex = 0;
    private bool isPaused;

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

    void OnEnable()
    {
        EventBus.Subscribe<OnPauseEvent>(DisableShoot);
        EventBus.Subscribe<OnResumeEvent>(EnableShoot);
    }
    void OnDisable()
    {
        EventBus.UnSubscribe<OnPauseEvent>(DisableShoot);
        EventBus.UnSubscribe<OnResumeEvent>(EnableShoot);
    }

    private void Update()
    {
        if (isPaused)
            return;

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

    private void DisableShoot(OnPauseEvent e)
    {
        isPaused = true;
    }

    private void EnableShoot(OnResumeEvent e)
    {
        isPaused = false;
    }
}
