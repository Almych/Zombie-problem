using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class InventoryDraw : MonoBehaviour
{
    public static InventoryDraw Instance;
    private Dictionary<Weapon, TMP_Text> melliWeapons = new Dictionary<Weapon, TMP_Text>();
    private Dictionary<ItemObject, TMP_Text> items = new Dictionary<ItemObject, TMP_Text>();
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    
    public void AddItem(ItemSlotConfig itemSlot)
    {
        items[itemSlot.itemObject] = itemSlot.itemAmount;
    }

    public void AddWeapon(WeaponSlotConfig weaponSlot)
    {
        melliWeapons[weaponSlot.weapon] = weaponSlot.weaponBulletAmount;
    }


    public async void ShowBulletAmount(int bullet, Weapon weapon)
    {
        TMP_Text result = null;
        await Task.Run(() => {result = CheckWeaponBullet(weapon); });
        if (result != null)
        {
            result.text = bullet.ToString("n0");
        }
        
    }

    private TMP_Text CheckWeaponBullet(Weapon weapon) 
    {
        var keys = melliWeapons.Keys.ToList();
        var values = melliWeapons.Values.ToList();
        for (int i = 0; i < keys.Count; ++i)
        {
            if (keys[i] == weapon)
            {
                return values[i];
            }
        }
        return null;
    }

    public async void ShowItemAmount(int bullet, ItemObject weapon)
    {
        TMP_Text result = null;
        await Task.Run(() => { result = CheckItemAmount(weapon); });
        if (result != null)
        {
            result.text = bullet.ToString("n0");
        }

    }

    private TMP_Text CheckItemAmount(ItemObject weapon)
    {
        var keys = items.Keys.ToList();
        var values = items.Values.ToList();
        for (int i = 0; i < keys.Count; ++i)
        {
            if (keys[i] == weapon)
            {
                return values[i];
            }
        }
        return null;
    }


}




