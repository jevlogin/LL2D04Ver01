using UnityEngine;


namespace JevLogin.Lesson07.Observer
{
    public sealed class ObserverTest : MonoBehaviour
    {
        #region Fields

        public Enemy Enemy;
        public Enemy Enemy2;
        public IHit EnemyHit;
        private Camera _mainCamera;

        private float _deticatedDistance = 20.0f;
        public float Damage;

        #endregion


        #region UnityMethods

        private void Start()
        {
            _mainCamera = Camera.main;
            var listenerHitShowDamage = new ListenerHitShowDamage();
            EnemyHit = Enemy2;
            listenerHitShowDamage.Add(Enemy);
            listenerHitShowDamage.Add(EnemyHit);
        }

        private void Update()
        {
            if (Input.GetButtonDown(AxisManager.FIRE1))
            {
                if (Physics.Raycast(_mainCamera.ScreenPointToRay(Input.mousePosition), out var hit, _deticatedDistance))
                {
                    if (hit.collider.TryGetComponent<IHit>(component: out var enemy))
                    {
                        enemy.Hit(Damage);
                    }
                }
            }
        } 

        #endregion
    }
}