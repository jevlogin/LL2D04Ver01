using UnityEngine;


namespace JevLogin.Bridge
{
    public sealed class Infantry : IMove
    {
        public void Move()
        {
            Debug.Log("Move Bridge");
        }
    }
}