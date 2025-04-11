using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class InventoryMenu : MonoBehaviour
{
    [SerializeField] private Button toggleButton;
    [SerializeField] private float slideDuration = 0.5f;
    [SerializeField] private float slideXOffset = -800f;

    private bool isOpen = true;
    private Vector2 closedPos;
    private Vector2 openPos;
    private RectTransform inventoryPanel;

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        inventoryPanel = GetComponent<RectTransform>();
        openPos = inventoryPanel.anchoredPosition;
        closedPos = openPos + new Vector2(slideXOffset, 0f);

        toggleButton.onClick.AddListener(ToggleInventory);
        ToggleInventory();
    }

    private void ToggleInventory()
    {
        isOpen = !isOpen;
        Vector2 targetPos = isOpen ? openPos : closedPos;

        inventoryPanel
            .DOAnchorPos(targetPos, slideDuration)
            .SetEase(Ease.InOutCubic); // You can change the easing style as needed
    }
}
