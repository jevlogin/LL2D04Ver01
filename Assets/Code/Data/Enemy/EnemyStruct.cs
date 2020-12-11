using System;
using UnityEngine;

namespace JevLogin
{
    [Serializable]
    public struct EnemyStruct
    {
        [Range(0, 100)] public float Speed;
        [Range(0,100)] public int HealthPoint;
    }
}