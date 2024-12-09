using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WeaponSlotConfig : MonoBehaviour
{
    public Image weaponLabel;
    public TMP_Text weaponBulletAmount;
    public MelliWeapon weapon;


    private void OnEnable()
    {
        weapon.onShootAmount += InventoryDraw.Instance.ShowBulletAmount;
    }

    private void OnDisable()
    {
        weapon.onShootAmount -= InventoryDraw.Instance.ShowBulletAmount;
    }
}
