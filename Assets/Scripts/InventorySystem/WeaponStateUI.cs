using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WeaponStateUI : MonoBehaviour
{
    [SerializeField] private Image weaponIcon;
    [SerializeField] private TMP_Text weaponAmountText;
    [SerializeField] private GameObject ammoContainer;

    public static WeaponStateUI Instance { get; private set; }

    private readonly Color usedBulletColor = Color.black;

    private readonly List<Image> pooledBulletIcons = new();
    private readonly Dictionary<RangeWeapon, int> usedBullets = new();
    private const string endLessSign = "∞";
    private IWeapon currentWeapon;
    private RectTransform ammoContainerRect;
    private void Awake()
    {
        Instance = this;
        ammoContainerRect = GetComponent<RectTransform>();
        EventBus.Subscribe<OnWeaponSwitchEvent>(SwitchWeapon);
    }

    private void OnDestroy()
    {
        EventBus.UnSubscribe<OnWeaponSwitchEvent>(SwitchWeapon);
    }

    private void EnsureBulletIconsExist(int required)
    {
        while (pooledBulletIcons.Count < required)
        {
            Image bulletRect = ObjectPoolManager.FindObjectByName<Image>("BulletIcon");
            if (bulletRect == null)
            {
                Debug.LogWarning("BulletIcon not available in pool!");
                return;
            }

            bulletRect.gameObject.SetActive(true);
            pooledBulletIcons.Add(bulletRect);
        }
    }

    private void SwitchWeapon(OnWeaponSwitchEvent e)
    {
        if (e.Weapon == null)
            return;

        currentWeapon = e.Weapon;
        weaponIcon.sprite = currentWeapon.weaponSprite;

        if (currentWeapon is RangeWeapon rangeWeapon)
        {
            ammoContainer.SetActive(true);
            UpdateBulletAmount();


            EnsureBulletIconsExist(rangeWeapon.maxAmount);

            HideBullets();

            ShowLeftBullets(rangeWeapon);

            LayoutRebuilder.ForceRebuildLayoutImmediate(ammoContainerRect);
        }
        else
        {
            ResetAmount();
            ammoContainer.SetActive(false);
        }
    }

    private void ShowLeftBullets(RangeWeapon rangeWeapon)
    {
        int curr = rangeWeapon.currAmount;

        // Save actual used count
        usedBullets[rangeWeapon] = rangeWeapon.maxAmount - curr;

        for (int i = 0; i < rangeWeapon.maxAmount; i++)
        {
            var bullet = pooledBulletIcons[i];
            bullet.transform.SetParent(ammoContainer.transform, false);
            bullet.gameObject.SetActive(true);
            bullet.color = (i < curr) ? Color.white : usedBulletColor;
        }
    }


    public void HideBullets()
    {
        foreach (var bullet in pooledBulletIcons)
            bullet.gameObject.SetActive(false);
    }
    public void UseBullet()
    {
        if (currentWeapon is not RangeWeapon rangeWeapon || !usedBullets.ContainsKey(rangeWeapon))
            return;

        int used = usedBullets[rangeWeapon];
        if (used >= rangeWeapon.maxAmount)
            return;

        for (int i = rangeWeapon.maxAmount - 1; i >= 0; i--)
        {
            if (pooledBulletIcons[i].color != usedBulletColor)
            {
                pooledBulletIcons[i].color = usedBulletColor;
                usedBullets[rangeWeapon] = used + 1;
                break;
            }
        }
    }

    public void Reload()
    {
        if (currentWeapon is not RangeWeapon rangeWeapon)
            return;

        int used = rangeWeapon.maxAmount - rangeWeapon.currAmount;
        usedBullets[rangeWeapon] = used;

        for (int i = 0; i < rangeWeapon.maxAmount; i++)
        {
            pooledBulletIcons[i].color = (i < rangeWeapon.currAmount) ? Color.white : usedBulletColor;
        }

        UpdateBulletAmount();
    }

    public void UpdateBulletAmount()
    {
        if(currentWeapon is RangeWeapon rangeWeapon && !rangeWeapon.isBaseWeapon)
        {
            weaponAmountText.text = rangeWeapon.totalAmount.ToString();
        }
        else
        {
            weaponAmountText.text = endLessSign;
        }
    }

    private void ResetAmount()
    {
        weaponAmountText.text = string.Empty;
    }
}
