
public interface IWaveConfig
{
    int TotalWaves { get; }

    public void InitConfig();
    Wave GetWave(int index);
    Wave GetPreWave(int index);
    void GetAllEnemyTypesInitiate();
}
