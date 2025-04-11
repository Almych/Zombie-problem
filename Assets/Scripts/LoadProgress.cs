using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class LoadProgressText : MonoBehaviour
{
    public string[] loadTexts;
    private TMP_Text loadText;
    private int index;

    void Awake()
    {
        loadText = transform.GetChild(0).GetComponent<TMP_Text>();
        EventBus.Subscribe<OnLoadEvent>(DescribeProgress);
    }

    void OnDestroy()
    {
        EventBus.UnSubscribe<OnLoadEvent>(DescribeProgress);
    }

    public void DescribeProgress(OnLoadEvent e)
    {
        if (index > loadTexts.Length-1)
            index = 0;

        loadText.text = loadTexts[index];
        index++;
    }
}
