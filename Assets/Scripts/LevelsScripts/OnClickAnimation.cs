using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OnClickAnimation : MonoBehaviour
{
    void Update()
    {
        if (IsPointerOverAnyButton())
        {
            Debug.Log("Pointer is over a button!");
        }
        else
        {
            Debug.Log("Pointer is not over a button.");
        }
    }

    private bool IsPointerOverAnyButton()
    {
        // Create a pointer event data instance
        PointerEventData pointerData = new PointerEventData(EventSystem.current)
        {
            position = Input.mousePosition
        };

        // Create a list to store the results of the raycast
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointerData, results);

        // Check if any of the results hit a button
        foreach (RaycastResult result in results)
        {
            if (result.gameObject.GetComponent<UnityEngine.UI.Button>() != null)
            {
                return true; // A button is under the pointer
            }
        }

        return false; // No button is under the pointer
    }
}
