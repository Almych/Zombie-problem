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
    public int startXPosition;
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
            obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
            var content = obj.transform.GetChild(0);
            content.GetComponent<Image>().sprite = inventory.slots[i].item.prefab;
            //if (inventory.slots[i].item.GetComponent<IItemThrowable>() != null ) 
            //content.GetComponent<Button>().onClick.AddListener(inventory.slots[i].item.GetComponent<IItemThrowable>().Throw);
            content.GetChild(0).GetComponent<TextMeshProUGUI>().text = inventory.slots[i].amount.ToString("n0");
        }
    }

    private Vector3 GetPosition(int i)
    {
        return new Vector3(startXPosition + spacesBetweenX * (i % collumnsSpaces), 0f, 0f);
    }
}
