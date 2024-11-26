using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Rendering;
using System.Collections.Generic;
using Unity.VisualScripting;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Linq;
using System.Threading.Tasks;

public class InventoryDraw : MonoBehaviour
{
    public Inventory inventory;
    public GameObject slotUi;
    public int spacesBetweenX;
    public int startXPositionItems;
    public int startXPositionWeapons;
    public int spacesBetweenY;
    public int collumnsSpaces;
    private int currentBulletAmount;
    private MelliWeapon melliEx;
    private Dictionary<MelliWeapon, TextMeshProUGUI> weaponBulletUi = new Dictionary<MelliWeapon, TextMeshProUGUI>();
    private float valueB;
    
    private void Start()
    {
        CreateDisplay();

        var keys = weaponBulletUi.Keys.ToList();
        for (int i = 0; i < keys.Count; i++)
        {
            keys[i].onShootAmount = ReadFloat;
        }
    }

    private void CreateDisplay()
    {
        for (int i = 0; i < inventory.slots.Count; i++)
        {
            var obj = Instantiate(slotUi, Vector3.zero, Quaternion.identity, transform);
            obj.GetComponent<RectTransform>().localPosition = GetPosition(startXPositionItems, i);
            var content = obj.transform.GetChild(0);
            content.GetComponent<Image>().sprite = inventory.slots[i].item.prefab;
            if(inventory.slots[i].item is GranadeItem granade)
            {
                content.GetComponent<Button>().onClick.AddListener(granade.granade.Throw);
            }
            content.GetChild(0).GetComponent<TextMeshProUGUI>().text = inventory.slots[i].amount.ToString("n0");
        }


        for (int i = 0; i < inventory.weaponSlots.Length; i++)
        {
            var obj = Instantiate(slotUi, Vector3.zero, Quaternion.identity, transform);
            obj.GetComponent<RectTransform>().localPosition = GetPosition(startXPositionWeapons, i);
            var content = obj.transform.GetChild(0);
            content.GetComponent<Image>().sprite = inventory.weaponSlots[i].weaponIcon;
            if (inventory.weaponSlots[i] is MelliWeapon melli)
            {
              var gun = content.GetChild(0).GetComponent<TextMeshProUGUI>();
                gun.text= melli.totalBullets.ToString("n0");
                melliEx = melli;
                weaponBulletUi[melli] = gun;
            }
        }
    }

   

    private void OnDisable()
    {
        var keys = weaponBulletUi.Keys.ToList();
        var values = weaponBulletUi.Values.ToList();
        for (int i = 0; i < keys.Count; i++)
        {
            keys[i].onShootAmount -= ReadFloat;
        }
    }

    private async void ReadFloat(float bullet, MelliWeapon weapon)
    {
        TextMeshProUGUI result = null;
        await Task.Run(() => {result = CheckWeaponBullet(weapon); });
        if (result != null)
        {
            result.text = bullet.ToString("n0");
        }
        Debug.Log(result);
    }

    private TextMeshProUGUI CheckWeaponBullet(MelliWeapon weapon)
    {
        var keys = weaponBulletUi.Keys.ToList();
        var values = weaponBulletUi.Values.ToList();
        for (int i = 0; i < keys.Count; ++i)
        {
            if (keys[i] == weapon)
            {
                return values[i];
            }
        }
        return null;
    }

    private Vector3 GetPosition(int startXPosition, int i)
    {
        return new Vector3(startXPosition + spacesBetweenX * (i % collumnsSpaces), 0f, 0f);
    }
}
