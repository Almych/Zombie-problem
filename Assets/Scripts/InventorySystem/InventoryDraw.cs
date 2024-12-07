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
    public GameObject slotUi;
    public int spacesBetweenX;
    public int startXPositionItems;
    public int startXPositionWeapons;
    public int spacesBetweenY;
    public int collumnsSpaces;
    private Dictionary<WeaponSlot, TextMeshProUGUI> weapons = new Dictionary<WeaponSlot, TextMeshProUGUI>();
    private Dictionary<ItemSlot, TextMeshProUGUI> items = new Dictionary<ItemSlot, TextMeshProUGUI>();
    private static List<WeaponSlot> weaponInventory =  new List<WeaponSlot>();
    private static List<ItemSlot> itemInventory = new List<ItemSlot>();
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    private void Start()
    {
        CreateDisplay();
    }

    public void AddWeapon(WeaponSlot weaponSlot)
    {
        weaponInventory.Add(weaponSlot);
    }

    public void AddItem(ItemSlot itemSlot)
    {
        itemInventory.Add(itemSlot);
    }


    private void CreateDisplay()
    {
        Debug.Log(itemInventory.Count);
        for (int i = 0; i < itemInventory.Count; i++)
        {
            Debug.Log(itemInventory[i]);
            var obj = Instantiate(slotUi, Vector3.zero, Quaternion.identity, transform);
            obj.GetComponent<RectTransform>().localPosition = GetPosition(startXPositionItems, i);
            var content = obj.transform.GetChild(0);
            content.GetComponent<Image>().sprite = itemInventory[i].item.prefab;
            content.GetComponent<Button>().onClick.AddListener(itemInventory[i].item.UseItem);
            var amountUi = content.GetChild(0).GetComponent<TextMeshProUGUI>();
            amountUi.text = itemInventory[i].item.amount.ToString("n0");
            items[itemInventory[i]] = amountUi;
        }


        for (int i = 0; i < weaponInventory.Count; i++)
        {
            var obj = Instantiate(slotUi, Vector3.zero, Quaternion.identity, transform);
            obj.GetComponent<RectTransform>().localPosition = GetPosition(startXPositionWeapons, i);
            var content = obj.transform.GetChild(0);
            content.GetComponent<Image>().sprite = weaponInventory[i].weapon.weaponIcon;
            var gun = content.GetChild(0).GetComponent<TextMeshProUGUI>();
            if (weaponInventory[i].weapon is MelliWeapon melli)
            {
                gun.text = melli.totalBullets.ToString("n0");
                weapons[weaponInventory[i]] = gun;
            }
        }
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
        var keys = weapons.Keys.ToList();
        var values = weapons.Values.ToList();
        for (int i = 0; i < keys.Count; ++i)
        {
            if (keys[i].weapon == weapon)
            {
                return values[i];
            }
        }
        return null;
    }

    public async void ShowItemAmount(int bullet, ItemObject weapon)
    {
        TextMeshProUGUI result = null;
        await Task.Run(() => { result = CheckItemAmount(weapon); });
        if (result != null)
        {
            result.text = bullet.ToString("n0");
        }

    }

    private TextMeshProUGUI CheckItemAmount(ItemObject weapon)
    {
        var keys = items.Keys.ToList();
        var values = items.Values.ToList();
        for (int i = 0; i < keys.Count; ++i)
        {
            if (keys[i].item == weapon)
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



public abstract class WeaponSlot
{
    internal protected Weapon weapon;
    protected WeaponSlot(Weapon weapon)
    {
        this.weapon = weapon; 
    }
}
public class ColdWeaponSlot: WeaponSlot
{
    public ColdWeaponSlot(ColdWeapon weapon) : base(weapon)
    {
        this.weapon = weapon;
    }
}

public class MelliWeaponSlot : WeaponSlot
{
    public MelliWeaponSlot(MelliWeapon weapon) : base(weapon)
    {
        this.weapon = weapon;
    }

    private void OnEnable()
    {
        (weapon as MelliWeapon).onShootAmount += InventoryDraw.Instance.ShowBulletAmount;
    }

    private void OnDisable()
    {
        (weapon as MelliWeapon).onShootAmount -= InventoryDraw.Instance.ShowBulletAmount;
    }
}
[System.Serializable]
public class ItemSlot 
{
    public ItemObject item;
    public ItemSlot(ItemObject item)
    {
        this.item = item;
    }

    private void OnEnable()
    {
        item.OnItemUse += InventoryDraw.Instance.ShowItemAmount;
    }

    private void OnDisable()
    {
        item.OnItemUse -= InventoryDraw.Instance.ShowItemAmount;
    }
}
