﻿using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Object = UnityEngine.Object;


namespace JevLogin
{
    public sealed class EnemyAsteroidPool : GenericObjectPool<Asteroid>
    {
        public EnemyAsteroidPool(Pool<Asteroid> poolAsteroid, Transform parentTransform) : base(poolAsteroid, parentTransform)
        {

        }
    }
}