public class PauseMenu : BaseMenu
{
    public void ShowMenu()
    {
        base.ShowMenu(); 
    }

    public override void ShowMenu(int stars = 0, float timeSpent = 0, int damageTaken = 0)
    {
        base.ShowMenu(stars, timeSpent, damageTaken);
    }
}
