using System;
using UnityEngine;


namespace JevLogin
{
    public sealed class PlayerView : MonoBehaviour, ICollisionDetect
    {
        public event Action<Collider2D> CollisionDetectChange = delegate(Collider2D collider2D) { };

        private void OnCollisionEnter2D(Collision2D collision)
        {
            CollisionDetectChange.Invoke(collision.collider);
        }

        public void CollisionDetect()
        {
            Debug.Log("Произошла коллизия через событие");
        }
    }
}