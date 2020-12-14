using UnityEngine;


namespace JevLogin
{
    public sealed class PlayerShooter : IExecute
    {
        private PlayerInitialization _playerInitialization;
        private Rigidbody2D _bullet;
        private Transform _barrel;
        private float _force;

        public PlayerShooter(PlayerInitialization playerInitialization)
        {
            _playerInitialization = playerInitialization;
            _bullet = playerInitialization.GetPlayerModel().PlayerComponents.BulletRigidbody;
            _barrel = playerInitialization.GetPlayerModel().PlayerComponents.BarrelTransform;
            _force = playerInitialization.GetPlayerModel().PlayerStruct.Force;
        }

        public void Execute(float deltaTime)
        {
            //throw new System.NotImplementedException();

            if (Input.GetButtonDown("Fire1"))
            {
                var temAmmunition = Object.Instantiate(_bullet, _barrel.position, _barrel.rotation);
                temAmmunition.AddForce(_barrel.up * _force);
            }
        }
    }
}