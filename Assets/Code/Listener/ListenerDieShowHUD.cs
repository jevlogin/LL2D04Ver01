using System;
using System.Collections.Generic;
using UnityEngine;


namespace JevLogin
{
    public sealed class ListenerDieShowHUD
    {
        public event Action<int> ShowTheScoreAfterTheObjectsDeath;

        public void Add(IDie die)
        {
            die.OnDieChange += Die_OnDieChange;
        }

        public void Remove(IDie die)
        {
            die.OnDieChange -= Die_OnDieChange;
        }

        private void Die_OnDieChange(int value)
        {
            Debug.Log($"Кто-то умер {value}");

            ShowTheScoreAfterTheObjectsDeath?.Invoke(value);
        }

        internal void AddListObject(EnemyAsteroidPool enemyPool)
        {
            var list = enemyPool.GetList();
            foreach (var item in list)
            {
                if (item is IDie die)
                {
                    Add(die);
                }
            }
        }
    }
}