public interface IEnemy
{
    void TriggerAction();
    void Initiate(bool isSpawnedByEnemy = false);
    void TakeDamage(Damage damage);
}