using UnityEngine;


namespace JevLogin.Proxy
{
    public sealed class Weapon : IWeapon
    {
        public void Fire()
        {
            Debug.Log("Fire");
        }
    }
}