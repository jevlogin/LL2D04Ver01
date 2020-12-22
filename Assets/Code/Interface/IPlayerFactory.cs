using UnityEngine;


namespace JevLogin
{
    public interface IPlayerFactory
    {
        PlayerView CreatePlayer();
        PlayerModel CreatePlayerModel();
    }
}