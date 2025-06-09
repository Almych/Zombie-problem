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
            Debug.Log(bulletRect);
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
            ShowBulletAmount(rangeWeapon.totalAmount, rangeWeapon.isBaseWeapon);


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
        if (!usedBullets.TryGetValue(rangeWeapon, out int used))
        {
            used = 0;
            usedBullets[rangeWeapon] = 0;
        }

        for (int i = 0; i < rangeWeapon.maxAmount; i++)
        {
            var bullet = pooledBulletIcons[i];
            bullet.transform.SetParent(ammoContainer.transform, false);
            bullet.gameObject.SetActive(true);
            bullet.GetComponent<Image>().color = (i < rangeWeapon.maxAmount - used) ? Color.white : usedBulletColor;
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

        ShowBulletAmount(rangeWeapon.totalAmount, rangeWeapon.isBaseWeapon);
    }

    private void ShowBulletAmount(int total, bool isEndless)
    {
        if (!isEndless)
            weaponAmountText.text = total.ToString();
        else
            weaponAmountText.text = endLessSign;
    }

    private void ResetAmount()
    {
        weaponAmountText.text = "";
    }
}
