using System.Collections.Generic;
using UnityEngine;


namespace JevLogin
{
    public abstract class GenericObjectPool<T> where T : Component
    {
        private Queue<T> objects = new Queue<T>();
        public Pool<T> Pool;

        //TODO - возможно следует сделать свойство
        private Transform _transform;
        private Transform _transformPool;


        #region Singleton

        public static GenericObjectPool<T> Instance { get; private set; }

        public GenericObjectPool(Pool<T> pool, Transform transformParen)
        {
            Instance = this;
            Pool = pool;
            _transform = transformParen;
        }


        #endregion

        public T Get()
        {
            if (objects.Count == 0)
            {
                AddObjects(Pool.Size);
            }
            return objects.Dequeue();
        }

        public void ReturnToPool(T objectToReturn)
        {
            objectToReturn.gameObject.SetActive(false);

            objectToReturn.transform.SetParent(_transformPool);

            objects.Enqueue(objectToReturn);
        }

        private void AddObjects(int count)
        {
            _transformPool = new GameObject(ManagerName.POOL_BULLETS).transform;

            _transformPool.SetParent(_transform);

            for (int i = 0; i < count; i++)
            {
                var newObject = Object.Instantiate(Pool.Prefab);
                
                newObject.transform.SetParent(_transformPool);

                newObject.gameObject.SetActive(false);

                objects.Enqueue(newObject);
            }
        }

    }
}