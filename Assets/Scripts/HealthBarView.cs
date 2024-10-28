using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarView : MonoBehaviour
{


    private void OnEnable()
    {
        HealthBar.Instance.OnHealthChanged += View.Instance.HealthBarUpdate;
    }

    private void OnDisable()
    {
       HealthBar.Instance.OnHealthChanged -= View.Instance.HealthBarUpdate;
    }

   
}
