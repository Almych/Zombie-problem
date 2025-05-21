using UnityEngine;
using UnityEngine.EventSystems;
public class GrenadeThrowManager : MonoBehaviour
{
    public static GrenadeThrowManager Instance { get; private set; }

    [SerializeField] private Texture2D grenadeCursor;
    [SerializeField] private Vector2 cursorHotspot = Vector2.zero;

    private DamageGrenade currentGrenade;
    private Camera mainCam;

    private void Awake()
    {
        Instance = this;
        mainCam = Camera.main;
        UpdateSystem.CallUpdate += Tick;
    }

    private void OnDestroy()
    {
        UpdateSystem.CallUpdate -= Tick;
    }

    public void StartAiming(DamageGrenade grenade)
    {
        currentGrenade = grenade;
        Cursor.SetCursor(grenadeCursor, cursorHotspot, CursorMode.Auto);
    }

    private void Tick()
    {
        if (currentGrenade == null) return;

        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            Vector3 worldPos = mainCam.ScreenToWorldPoint(Input.mousePosition);
            worldPos.z = 0;

            currentGrenade.ThrowAt(worldPos);
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
            currentGrenade = null;
        }
    }
}
