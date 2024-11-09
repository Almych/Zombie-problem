using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class InventoryDraw : MonoBehaviour
{
    public Inventory inventory;
    public GameObject slotUi;
    public int spacesBetweenX;
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
            var obj = Instantiate(inventory.slots[i].item.prefab, Vector3.zero, Quaternion.identity);
            obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
            obj.GetComponentInChildren<TextMeshProUGUI>().text = inventory.slots[i].amount.ToString("n0");
        }
    }

    private Vector3 GetPosition(int i)
    {
        return new Vector3(spacesBetweenX * (i % collumnsSpaces), (-spacesBetweenY * (i / collumnsSpaces)), 0f);
    }
}
