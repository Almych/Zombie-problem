
public class DodgeAbility : IMoveAbility
{
    private int timeToDodge;
    private float frequency, amplitute = 1f;
    private bool changedMove;
    private Enemy enemy;

    public DodgeAbility(Enemy enemy, int timeToDodge, float frequency, float amplitute)
    {
        this.enemy = enemy;
        this.timeToDodge = timeToDodge;
        this.frequency = frequency;
        this.amplitute = amplitute;
    }


    public void OnMove()
    {
        if (changedMove)
        {
            return;
        }
        else
        {
            enemy.movable = new ZigZagMove(enemy.transform, enemy.rb, enemy.enemyConfig.speed, timeToDodge, amplitute, frequency);
            changedMove = true;
        }
    }
}