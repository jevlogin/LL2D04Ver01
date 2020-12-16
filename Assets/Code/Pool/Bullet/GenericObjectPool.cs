using System.Collections.Generic;
using UnityEngine;


namespace JevLogin
{
    public abstract class GenericObjectPool<T> where T : Component
    {
        private Queue<T> objects = new Queue<T>();
        public Pool<T> Pool;

        #region Singleton
        
        public static GenericObjectPool<T> Instance { get; private set; }

        protected GenericObjectPool(Pool<T> pool)
        {
            Instance = this;
            Pool = pool;
            Pool.Prefab = Resources.Load<T>(ManagerPath.BULLET_PATH);
        }


        #endregion

        public T Get()
        {
            if (objects.Count == 0)
            {
                AddObjects(1);
            }
            return objects.Dequeue();
        }

        public void ReturnToPool(T objectToReturn)
        {
            objectToReturn.gameObject.SetActive(false);
            objects.Enqueue(objectToReturn);
        }

        private void AddObjects(int count)
        {
            var newObject = Object.Instantiate(Pool.Prefab);
            newObject.gameObject.SetActive(false);
            objects.Enqueue(newObject);

        }

    }
}