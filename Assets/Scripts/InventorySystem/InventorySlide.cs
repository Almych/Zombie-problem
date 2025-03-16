using System.Collections;
using Unity.Properties;
using UnityEngine;
using UnityEngine.UI;

public class InventoryMenu : MonoBehaviour
{
    [SerializeField] private RectTransform inventoryPanel;
    [SerializeField] private Button toggleButton;
    [SerializeField] private float slideSpeed = 10f;
    [SerializeField] private float slideXOffset = -800f;
    private bool isOpen = true;
    private Vector2 closedPos;
    private Vector2 openPos;
    private Vector2 targetPos;
    private bool canSlide = false;
    private void Init()
    {
        openPos = inventoryPanel.anchoredPosition; 
        closedPos = openPos + new Vector2(slideXOffset, 0f);

        toggleButton.onClick.AddListener(ToggleInventory);
    }

    private void ToggleInventory()
    {
        isOpen = !isOpen;
        targetPos = isOpen ? openPos : closedPos;
        canSlide = true;
    }

    private void Tick()
    {
        if (!canSlide)
            return;
        inventoryPanel.anchoredPosition = Vector2.Lerp(inventoryPanel.anchoredPosition,targetPos,Time.deltaTime * slideSpeed);

        if (Vector2.Distance(inventoryPanel.anchoredPosition, targetPos) < 0.1f)
        {
            inventoryPanel.anchoredPosition = targetPos;
            canSlide = false; 
        }
    }

    void Awake()
    {
        Init();
        UpdateSystem.OnUpdate += Tick;
    }

    void OnDestroy()
    {
        UpdateSystem.OnUpdate -= Tick;
    }


}
