using UnityEngine;

namespace JevLogin
{
    public sealed class Pool<T> where T : Component
    {
        public T Prefab;
        public int Size;
    }
}