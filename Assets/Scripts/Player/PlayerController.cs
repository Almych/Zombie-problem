using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private LayerMask collectable;
    [SerializeField] private PlayInventory inventory;
    [SerializeField] private Transform shootPoint, gun;
    public static PlayerController Instance;
    private IWeapon[] weaponSlots = new IWeapon[2];
    private int activeWeaponIndex = 0;
    private bool isPaused;
    private SpriteRenderer gunSprite;
    private void Awake()
    {
        if(Instance == null)
            Instance = this;
        EventBus.Subscribe<OnPauseEvent>(OnPause);
        EventBus.Subscribe<OnCollectEvent>(CollectCollectables);
        UpdateSystem.CallUpdate += Tick;
    }

    void Start()
    {
        Init();
    }

    private void OnDestroy()
    {
        EventBus.UnSubscribe<OnPauseEvent>(OnPause);
        EventBus.UnSubscribe<OnCollectEvent>(CollectCollectables);
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
            for (int i = 0; i < inventory.weaponSlots.Count; i++)
            {
                EquipWeapon(inventory.weaponSlots[i]);
            }
        }
    }

    public IWeapon FindRangeWeapon(WeaponConfig weaponConfig)
    {
        if (weaponConfig == null)
            return null;
        for (int i = 0; i < inventory.weaponSlots.Count; i++)
        {
            if(inventory.weaponSlots[i] == weaponConfig)
            {
                return weaponSlots[i];
            }
        }
        return null;
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

    public void EquipWeapon(WeaponConfig weaponConfig)
    {
        if (weaponConfig == null) return;
        CreateWeaponSlot(weaponConfig);
        SwitchWeapon();
    }


    private void CreateWeaponSlot(WeaponConfig weaponConfig)
    {
        var index = FindFreeWeaponSlotIndex();
        if(index != null)
        {
            if (weaponConfig is MeleeWeaponConfig meleeWeaponConfig)
            {
                weaponSlots[index.Value] = new MeleeWeapon(meleeWeaponConfig);
            }
            else if (weaponConfig is RangeWeaponConfig rangeWeaponConfig)
            {
                weaponSlots[index.Value] = new RangeWeapon(rangeWeaponConfig, this, shootPoint);
            }
        }
       
    }




    private void SwitchWeapon()
    {
        if (weaponSlots[activeWeaponIndex] is RangeWeapon range && range.isReloading || weaponSlots[activeWeaponIndex] == null)
            return;
        activeWeaponIndex = (activeWeaponIndex + 1) % inventory.weaponSlots.Count;
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

    private void CollectCollectables(OnCollectEvent e)
    {
        if (e.collectable is InventoryItem item)
        {
           InventoryManager.Instance.AddToInventory(item);
        }
        else if (e.collectable is WeaponConfig config)
        {
            inventory.AddWeapon(config, CreateWeaponSlot);
        }
        else if (e.collectable is int coin)
        {
            InventoryManager.Instance.CollectCoins(coin);
        }
    }

    private int? FindFreeWeaponSlotIndex()
    {
        for (int i = 0; i < weaponSlots.Length; i++)
        {
            if (weaponSlots[i] == null)
                return i;
        }
        return null;
    }

}
