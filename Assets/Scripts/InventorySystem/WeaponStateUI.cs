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

    private readonly List<GameObject> pooledBulletIcons = new();
    private readonly Dictionary<RangeWeapon, int> usedBullets = new();

    private IWeapon currentWeapon;

    private void Awake()
    {
        Instance = this;
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
            var bulletRect = ObjectPoolManager.FindObjectByName<RectTransform>("BulletIcon");
            if (bulletRect == null)
            {
                Debug.LogWarning("BulletIcon not available in pool!");
                return;
            }

            bulletRect.gameObject.SetActive(true);
            pooledBulletIcons.Add(bulletRect.gameObject);
        }
    }

    private void SwitchWeapon(OnWeaponSwitchEvent e)
    {
        currentWeapon = e.Weapon;

        if (currentWeapon.weaponSprite != null)
            weaponIcon.sprite = currentWeapon.weaponSprite;

        if (currentWeapon is RangeWeapon rangeWeapon)
        {
            ammoContainer.SetActive(true);
            SetTotalAmount(rangeWeapon.totalAmount);

            if (!usedBullets.TryGetValue(rangeWeapon, out int used))
            {
                used = 0;
                usedBullets[rangeWeapon] = 0;
            }

            // Ensure enough bullet icons
            EnsureBulletIconsExist(rangeWeapon.maxAmount);

            // Hide all icons
            foreach (var bullet in pooledBulletIcons)
                bullet.SetActive(false);

            // Show needed icons and set color
            for (int i = 0; i < rangeWeapon.maxAmount; i++)
            {
                var bullet = pooledBulletIcons[i];
                bullet.transform.SetParent(ammoContainer.transform, false);
                bullet.SetActive(true);
                bullet.GetComponent<Image>().color = (i < rangeWeapon.maxAmount - used) ? Color.white : usedBulletColor;
            }

            LayoutRebuilder.ForceRebuildLayoutImmediate(ammoContainer.GetComponent<RectTransform>());
        }
        else
        {
            HideAmount();
            ammoContainer.SetActive(false);
        }
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
            var img = pooledBulletIcons[i].GetComponent<Image>();
            if (img.color != usedBulletColor)
            {
                img.color = usedBulletColor;
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
            var img = pooledBulletIcons[i].GetComponent<Image>();
            img.color = (i < rangeWeapon.currAmount) ? Color.white : usedBulletColor;
        }

        SetTotalAmount(rangeWeapon.totalAmount);
    }

    private void SetTotalAmount(int total)
    {
        weaponAmountText.text = total.ToString();
    }

    private void HideAmount()
    {
        weaponAmountText.text = "";
    }
}
