namespace JevLogin
{
    public interface  IEnemyFactory 
    {
        Enemy Create(HealthPoint healthPoint);
    }
}