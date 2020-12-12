﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace JevLogin
{
    public sealed class Asteroid : Enemy
    {
        public void DependencyInjectHealth(HealthPoint healthPoint)
        {
            HealthPoint = healthPoint;
        }
    }
}