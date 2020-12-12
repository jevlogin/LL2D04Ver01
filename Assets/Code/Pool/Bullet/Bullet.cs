using System;
using UnityEngine;


namespace JevLogin
{
    public sealed class Bullet : MonoBehaviour
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
                    var spriteRenderer = GetComponent<SpriteRenderer>();
                    if (spriteRenderer)
                    {
                        _bulletSprite = spriteRenderer.sprite;
                    }
                    else
                    {
                        _bulletSprite = Resources.Load<SpriteRenderer>(ManagerPath.BULLET_PATH).sprite;
                    }
                }
                return _bulletSprite;
            }
        }

        #endregion
    }
}