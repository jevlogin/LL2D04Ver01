using System;
using UnityEngine;


namespace JevLogin
{
    [CreateAssetMenu(fileName = "NewBullet", menuName = ManagerPath.BULLET_DATA_PATH, order = 51)]
    public sealed class Bullet : ScriptableObject
    {
        #region Fields

        [SerializeField] private int _damageAttack;
        [SerializeField] private Sprite _bulletSprite;

        #endregion


        #region Properties

        public int DamageAttack
        {
            get
            {
                if (_damageAttack <= 0)
                {
                    _damageAttack = 10;
                }
                return _damageAttack;
            }
        }

        public Sprite BulletSprite
        {
            get
            {
                if (_bulletSprite == null)
                {
                    _bulletSprite = Resources.Load<Sprite>(ManagerPath.BULLET_PATH);
                }
                return _bulletSprite;
            }
        }

        #endregion
    }
}