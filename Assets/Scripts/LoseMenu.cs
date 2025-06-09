using TMPro;
using UnityEngine;

public class LoseMenu : BaseMenu
{
    [SerializeField] private TMP_Text time, takenDamage;

    public override void ShowMenu(int stars = 0, float timeSpent = 0, int damageTaken = 0)
    {
        base.ShowMenu(stars, timeSpent, damageTaken);
        time.text = $" {timeSpent:F1}s";
        takenDamage.text = $"{damageTaken}";
    }
}
