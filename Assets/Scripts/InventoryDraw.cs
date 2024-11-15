using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
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
    private void Start()
    {
        CreateDisplay();
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
            if (inventory.weaponSlots[i] is MelliGun melli)
            {
                content.GetChild(0).GetComponent<TextMeshProUGUI>().text = melli.totalBulletAmount.ToString("n0");
            }
        }
    }

    private Vector3 GetPosition(int startXPosition, int i)
    {
        return new Vector3(startXPosition + spacesBetweenX * (i % collumnsSpaces), 0f, 0f);
    }
}
