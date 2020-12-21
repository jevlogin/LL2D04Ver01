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
            EnemyShipPool = enemyShipPool;
        }

        public Enemy EnemyShip { get => _enemyShip; private set => _enemyShip = value; }

        public EnemyShipPool EnemyShipPool { get => _enemyShipPool; private set => _enemyShipPool = value; }

        #endregion


        #region IInitialization

        public void Initialization()
        {
            EnemyShip = EnemyShipPool.Get();
            EnemyShip.transform.position = new Vector2(Random.Range(-5, 5), Random.Range(-3, 3));
            EnemyShip.gameObject.SetActive(true);
        }

        #endregion
    }
}