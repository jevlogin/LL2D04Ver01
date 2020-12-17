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


        #region Singleton

        public static GenericObjectPool<T> Instance { get; private set; }

        public GenericObjectPool(Pool<T> pool, PlayerInitialization playerInitialization)
        {
            Instance = this;
            Pool = pool;
            _transform = playerInitialization.GetPlayerModel().PlayerComponents.BarrelTransform;
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
            objectToReturn.transform.position = _transform.position;
            objectToReturn.transform.rotation = _transform.rotation;
            objects.Enqueue(objectToReturn);
        }

        private void AddObjects(int count)
        {
            var pool = new GameObject(ManagerName.POOL_BULLETS);

            for (int i = 0; i < count; i++)
            {
                var newObject = Object.Instantiate(Pool.Prefab);
                
                newObject.transform.SetParent(pool.transform);

                newObject.transform.position = _transform.position;
                newObject.transform.rotation = _transform.rotation;

                newObject.gameObject.SetActive(false);

                objects.Enqueue(newObject);
            }
        }

    }
}