
using UnityEngine;

public class ShootController : MonoBehaviour
{
    [SerializeField] private PlayInventory inventory;
    [SerializeField] private Transform shootPoint;
    private IWeapon[] weaponSlots = new IWeapon[2];
    private int activeWeaponIndex = 0;
    private bool isPaused;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        Init();
        EventBus.Subscribe<OnPauseEvent>(OnPause);
        UpdateSystem.CallUpdate += Tick;
    }

    private void Init()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (inventory != null)
        {
            EquipWeapon(inventory.weaponSlots);
        }
    }

    private void OnDestroy()
    {
        EventBus.UnSubscribe<OnPauseEvent>(OnPause);
        UpdateSystem.CallUpdate -= Tick;
    }

    private void Tick()
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
        activeWeaponIndex = (activeWeaponIndex + 1) % weaponSlots.Length;
       spriteRenderer.sprite = inventory.weaponSlots[activeWeaponIndex].weaponSprite;
    }

    private void OnPause(OnPauseEvent e)
    {
        isPaused = e.IsPaused;
    }

   
}
