using UnityEngine;
public static class LevelRegister
{
    private static LevelConfig _currentConfig;
    private static int _currentLevel = 1;

    public static void SetCurrentLevel(LevelConfig config)
    {
        _currentConfig = config;
    }

    public static LevelConfig GetCurrentLevelConfig() => _currentConfig;

    public static void UnlockNextLevel() => _currentLevel++;

    public static int GetCurrentLevel()
    {
        EventBus.Publish(new OnLevelUnlock(_currentLevel));
        return _currentLevel;
    }
}
