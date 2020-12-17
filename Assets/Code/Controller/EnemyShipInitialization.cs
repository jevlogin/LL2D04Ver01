using UnityEngine;


namespace JevLogin
{
    public sealed class EnemyShipInitialization : IInitialization
    {
        private EnemyShipPool _enemyShipPool;
        private Enemy _enemyShip;



        public EnemyShipInitialization(EnemyShipPool enemyShipPool)
        {
            _enemyShipPool = enemyShipPool;
        }

        public Enemy EnemyShip { get => _enemyShip; private set => _enemyShip = value; }

        public void Initialization()
        {
            EnemyShip = _enemyShipPool.Get();
            EnemyShip.transform.position = new Vector2(Random.Range(-5, 5), Random.Range(-3, 3));
            EnemyShip.gameObject.SetActive(true);
        }
    }
}