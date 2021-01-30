using UnityEngine;


namespace JevLogin.Bridge
{
    public sealed class Cavalry : IMove
    {
        public void Move()
        {
            Debug.Log("Cavalry movement in Bridge");
        }
    }
}