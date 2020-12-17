using UnityEngine;


namespace JevLogin
{
    public sealed class EnemyShipPool : GenericObjectPool<Ship>
    {
        public EnemyShipPool(Pool<Ship> poolEnemyShip, Transform parentTransform) : base(poolEnemyShip, parentTransform)
        {

        }
    }
}