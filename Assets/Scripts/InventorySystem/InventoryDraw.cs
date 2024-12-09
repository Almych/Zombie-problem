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
    
    private List<GameObject> slots = new List<GameObject>();
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    private void Start()
    {
    }



    public async void ShowBulletAmount(int bullet, Weapon weapon)
    {
        TextMeshProUGUI result = null;
        await Task.Run(() => {result = CheckWeaponBullet(weapon); });
        if (result != null)
        {
            result.text = bullet.ToString("n0");
        }
        
    }

    private TextMeshProUGUI CheckWeaponBullet(Weapon weapon) 
    {
        //var keys = weapons.Keys.ToList();
        //var values = weapons.Values.ToList();
        //for (int i = 0; i < keys.Count; ++i)
        //{
        //    //if (keys[i].weapon == weapon)
        //    //{
        //    //    return values[i];
        //    //}
        //}
        return null;
    }

    //public async void ShowItemAmount(int bullet, ItemObject weapon)
    //{
    //    TextMeshProUGUI result = null;
    //    await Task.Run(() => { result = CheckItemAmount(weapon); });
    //    if (result != null)
    //    {
    //        result.text = bullet.ToString("n0");
    //    }

    //}

    //private TextMeshProUGUI CheckItemAmount(ItemObject weapon)
    //{
    //    var keys = items.Keys.ToList();
    //    var values = items.Values.ToList();
    //    for (int i = 0; i < keys.Count; ++i)
    //    {
    //        if (keys[i].item == weapon)
    //        {
    //            return values[i];
    //        }
    //    }
    //    return null;
    //}


}




