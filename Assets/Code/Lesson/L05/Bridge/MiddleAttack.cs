using UnityEngine;


namespace JevLogin.Bridge
{
    public sealed class MiddleAttack : IAttack
    {
        public void Attack()
        {
            Debug.Log("Middle Attack in Bridge");
        }
    }
}