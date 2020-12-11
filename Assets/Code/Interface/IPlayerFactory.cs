using UnityEngine;


namespace JevLogin
{
    public interface IPlayerFactory
    {
        GameObject CreatePlayer();
        PlayerModel CreatePlayerModel();
    }
}