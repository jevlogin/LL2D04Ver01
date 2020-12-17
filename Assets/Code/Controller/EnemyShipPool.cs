using UnityEngine;

namespace JevLogin
{
    internal class EnemyShipPool : GenericObjectPool<Ship>
    {
        public EnemyShipPool(Pool<Ship> poolEnemyShip, Transform parentTransform) : base(poolEnemyShip, parentTransform)
        {

        }
    }
}