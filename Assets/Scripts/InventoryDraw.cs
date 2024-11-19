using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Rendering;
using System.Collections.Generic;
using Unity.VisualScripting;

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
    private List<MelliWeapon> guns = new List<MelliWeapon>();
    private List<TextMeshProUGUI> amount = new List<TextMeshProUGUI>();
    private void Start()
    {
        CreateDisplay(); 

        for (int i = 0; i < guns.Count; i ++)
        {
            Debug.Log(guns[i]);
           
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
                gun.text= melli.totalBulletUi.ToString("n0");
                melliEx = melli;
                guns.Add(melli);
                amount.Add(gun);
            }
        }
    }

    private void OnEnable()
    {
        for (int i = 0; i < guns.Count; i++)
        {
            Debug.Log(guns[i]);
            guns[i].onShootAmount += ReturnFloat;
        }
    }

    private void OnDisable()
    {
        for (int i = 0; i < guns.Count; i++)
        {
            guns[i].onShootAmount -=  ReturnFloat;
        }
    }
    private int ReturnFloat( int value)
    {
        Debug.Log("fgffgf");
        return value;
    }
    private Vector3 GetPosition(int startXPosition, int i)
    {
        return new Vector3(startXPosition + spacesBetweenX * (i % collumnsSpaces), 0f, 0f);
    }
}
