namespace JevLogin
{
    public sealed class HealthPoint
    {
        public float Max { get; }
        public float Current { get; private set; }

        public HealthPoint(float max, float current)
        {
            Max = max;
            Current = current;
        }

        public void ChangeCurrentHealth(float healthPoint)
        {
            Current = healthPoint;
        }
    }
}