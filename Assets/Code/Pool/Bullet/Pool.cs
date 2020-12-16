using UnityEngine;

namespace JevLogin
{
    public sealed class Pool<T> where T : Component
    {
        public T Prefab;
        public int Size;

        public Pool(int count, string path)
        {
            Size = count;
            Prefab = Resources.Load<T>(path);
        }
    }
}