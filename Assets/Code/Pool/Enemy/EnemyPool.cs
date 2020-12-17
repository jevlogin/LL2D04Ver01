using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Object = UnityEngine.Object;


namespace JevLogin
{
    public sealed class EnemyPool : GenericObjectPool<Asteroid>
    {
        public EnemyPool(Pool<Asteroid> poolAsteroid, Transform parentTransform) : base(poolAsteroid, parentTransform)
        {

        }
    }
}