
public class DodgeAbility : Ability
{
    private int timeToDodge;
    private float frequency, amplitute = 1f;

    public DodgeAbility(int coolDownTicks, bool callOnce, Enemy enemy, int timeToDodge, float frequency, float amplitute) : base(coolDownTicks, callOnce, enemy)
    {
        this.frequency = frequency;
        this.amplitute = amplitute;
        this.timeToDodge = timeToDodge;
    }

    protected override void OnCall()
    {
        enemy.movable = new ZigZagMove(enemy.animator, enemy.transform, enemy.rb, enemy.enemyConfig.speed, amplitute, frequency);
    }
}