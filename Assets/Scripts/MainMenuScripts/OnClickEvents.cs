using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OnClickEvents : MonoBehaviour
{
   public string link;

    public void OpenLink()
    {
        Application.OpenURL(link);
    }
}
