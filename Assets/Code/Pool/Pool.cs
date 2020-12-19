using UnityEngine;


namespace JevLogin
{
    public sealed class Pool<T> where T : Component
    {
        #region Fields

        public T Prefab;
        public int Size;

        #endregion


        #region Properties

        public Pool(int count, string path)
        {
            Size = count;
            Prefab = Resources.Load<T>(path);
        }

        #endregion
    }
}