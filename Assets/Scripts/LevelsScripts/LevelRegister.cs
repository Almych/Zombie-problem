using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LevelRegister 
{
    private static LevelConfig _currentLevelConfig;
    private static int currentLevel = 1;

    //set level config
    public static void SetLevelConfig(LevelConfig levelConfig)
    {
        if (_currentLevelConfig != null)
            _currentLevelConfig = null;


        _currentLevelConfig = levelConfig;
    }

    public static LevelConfig GetLevelConfig()
    {
        return _currentLevelConfig;
    }

    public static void UnlockNextLevel()
    {
        currentLevel +=1;
    }

    public static int GetCurrentLEvel()
    {
        EventBus.Publish(new OnLevelUnlock(currentLevel));
        return currentLevel;
    }
}
