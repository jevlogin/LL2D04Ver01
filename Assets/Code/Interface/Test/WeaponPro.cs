using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace JevLogin.Bridge
{
    public sealed class WeaponPro : IWeapon
    {
        public void Fire()
        {
            Debug.Log("Fire");
        }
    }
}