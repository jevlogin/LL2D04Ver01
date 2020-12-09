using System;
using UnityEngine;


namespace JevLogin
{
    [Serializable]
    public sealed class PlayerComponents
    {
        public SpriteRenderer SpriteRenderer;
        public CircleCollider2D CircleCollider2D;
        public Transform Player;
        public Rigidbody2D BulletRigidbody;
    }
}