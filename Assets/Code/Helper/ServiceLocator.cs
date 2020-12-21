using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace JevLogin
{
    public static class ServiceLocator
    {
        private static readonly Dictionary<Type, object> _serviceContayner = new Dictionary<Type, object>();

        public static void SetService<T>(T value) where T : class
        {
            var typeValue = typeof(T);
            if (!_serviceContayner.ContainsKey(typeValue))
            {
                _serviceContayner[typeValue] = value;
            }
        }

        public static T Resolve<T>()
        {
            var type = typeof(T);

            if (_serviceContayner.ContainsKey(type))
            {
                return (T)_serviceContayner[type];
            }
            return default;
        }
    }
}