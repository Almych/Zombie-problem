using UnityEngine;
using UnityEngine.EventSystems;
public class GrenadeThrowManager : MonoBehaviour
{
    public static GrenadeThrowManager Instance { get; private set; }

    [SerializeField] private Texture2D grenadeCursor;
    [SerializeField] private Vector2 cursorHotspot = Vector2.zero;

    private ThrowableGrenade currentGrenade;
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

    public void StartAiming(ThrowableGrenade grenade)
    {
        currentGrenade = grenade;
        Cursor.SetCursor(grenadeCursor, cursorHotspot, CursorMode.Auto);
        EventBus.Publish(new OnAimEvent(true));
    }

    private void Tick()
    {
        if (currentGrenade == null) return;

        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            Vector3 mousePosition = Input.mousePosition;
            Ray ray = mainCam.ScreenPointToRay(mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

            if (hit.collider != null)
            {
                DefeatedEnemyTrigger defeat = hit.collider.GetComponent<DefeatedEnemyTrigger>();
                if (defeat != null)
                {
                    Vector3 worldPos = hit.point;
                    currentGrenade.ThrowAt(worldPos);
                    Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
                    currentGrenade = null;
                    EventBus.Publish(new OnAimEvent(false));
                    return;
                }
            }
        }
    }

}
