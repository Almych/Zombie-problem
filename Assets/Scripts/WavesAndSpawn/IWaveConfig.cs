using System.Collections.Generic;

public interface IWaveConfig
{
    int TotalWaves { get; }
    Wave GetWave(int index);
    Wave GetPreWave(int index);
    void GetAllEnemyTypesInitiate();
}
