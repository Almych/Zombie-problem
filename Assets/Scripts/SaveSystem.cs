using UnityEngine;

public static class SaveSystem
{
    public static void SaveStars(int levelId, int stars)
    {
        int savedStars = PlayerPrefs.GetInt($"Level_{levelId}_Stars", 0);
        if (stars > savedStars)
        {
            PlayerPrefs.SetInt($"Level_{levelId}_Stars", stars);
        }
    }

    public static int LoadStars(int levelId)
    {
        return PlayerPrefs.GetInt($"Level_{levelId}_Stars", 0);
    }

    public static void SaveUnlockedLevel(int levelId)
    {
        int maxUnlocked = PlayerPrefs.GetInt("UnlockedLevel", 1);
        if (levelId > maxUnlocked)
        {
            PlayerPrefs.SetInt("UnlockedLevel", levelId);
        }
    }

    public static int LoadUnlockedLevel()
    {
        return PlayerPrefs.GetInt("UnlockedLevel", 1);
    }
}
