using UnityEngine;

namespace JevLogin
{
    internal sealed class PlayerFactory
    {
        private readonly PlayerData _playerData;

        

        public PlayerFactory(PlayerData playerData)
        {
            _playerData = playerData;
            //_material = new Material(Shader.Find("Mobile/Particles/Additive"));
        }

        public Transform CreatePlayer()
        {
            return new GameObject("Player").AddSprite(_playerData.Sprite).AddCircleCollider2D().AddTrailRenderer().transform;
        }

    }
}