using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private LayerMask collectable;
    [SerializeField] private PlayInventory inventory;
    [SerializeField] private Transform shootPoint, gun;
    private IWeapon[] weaponSlots = new IWeapon[2];
    private int activeWeaponIndex = 0;
    private bool isPaused;
    private SpriteRenderer gunSprite;
    private void Awake()
    {
        EventBus.Subscribe<OnPauseEvent>(OnPause);
        UpdateSystem.CallUpdate += Tick;
    }

    void Start()
    {
        Init();
    }

    private void OnDestroy()
    {
        EventBus.UnSubscribe<OnPauseEvent>(OnPause);
        UpdateSystem.CallUpdate -= Tick;
    }

    private void Tick()
    {
        CollectItems();
        Shoot();
    }



    private void Init()
    {
       gunSprite = gun.transform.GetComponent<SpriteRenderer>();
        if (inventory != null)
        {
            EquipWeapon(inventory.weaponSlots);
        }
    }

    private void Shoot()
    {
        if (isPaused)
            return;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            weaponSlots[activeWeaponIndex]?.Execute();
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            SwitchWeapon();
        }

        if (Input.GetKeyDown(KeyCode.R) && weaponSlots[activeWeaponIndex] is RangeWeapon rangeWeapon)
        {
            rangeWeapon.Reload();
        }

    }

    public void EquipWeapon(IWeaponConfig[] weaponConfigs)
    {
        if (weaponConfigs.Length == 0) return;

        for (int i = 0; i < weaponSlots.Length; i++)
        {
            if (i >= weaponConfigs.Length) break;

            if (weaponConfigs[i] is MeleeWeaponConfig meleeWeaponConfig)
            {
                weaponSlots[i] = new MeleeWeapon(meleeWeaponConfig);
            }
            else if (weaponConfigs[i] is RangeWeaponConfig rangeWeaponConfig)
            {
                weaponSlots[i] = new RangeWeapon(rangeWeaponConfig, this, shootPoint);
            }
        }

        SwitchWeapon();
    }



    private void SwitchWeapon()
    {
        if (weaponSlots[activeWeaponIndex] is RangeWeapon range && range.isReloading)
            return;
        activeWeaponIndex = (activeWeaponIndex + 1) % weaponSlots.Length;
        gunSprite.sprite = inventory.weaponSlots[activeWeaponIndex].weaponSprite;
        EventBus.Publish(new OnWeaponSwitchEvent(weaponSlots[activeWeaponIndex]));
    }

    private void OnPause(OnPauseEvent e)
    {
        isPaused = e.IsPaused;
    }


    //colllect items using mouse!
    private void CollectItems()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero, Mathf.Infinity, collectable);

            if (hit.collider != null && hit.collider.GetComponent<ICollectable>() != null)
            {
                hit.collider.GetComponent<ICollectable>().OnCollect();
            }
        }
    }
}
