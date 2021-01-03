using UnityEngine;


namespace JevLogin.Bridge
{
    public sealed class MagicalAttack : IAttack
    {
        public void Attack()
        {
            Debug.Log("Magic Attack Bridge");
        }
    }
}