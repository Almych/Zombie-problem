
public class OnLevelClickEvent 
{
    public LevelConfig LevelConfig {  get; private set; }
    public OnLevelClickEvent(LevelConfig levelConfig)
    {
        LevelConfig = levelConfig;
    }
}
