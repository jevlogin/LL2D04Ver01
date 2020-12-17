using UnityEngine;


namespace JevLogin
{
    public sealed class EnemyShipInitialization : IInitialization
    {
        #region Fields

        private EnemyShipPool _enemyShipPool;
        private Enemy _enemyShip;

        #endregion


        #region Properties

        public EnemyShipInitialization(EnemyShipPool enemyShipPool)
        {
            _enemyShipPool = enemyShipPool;
        }

        public Enemy EnemyShip { get => _enemyShip; private set => _enemyShip = value; }

        #endregion


        #region IInitialization

        public void Initialization()
        {
            EnemyShip = _enemyShipPool.Get();
            EnemyShip.transform.position = new Vector2(Random.Range(-5, 5), Random.Range(-3, 3));
            EnemyShip.gameObject.SetActive(true);
        }

        #endregion
    }
}