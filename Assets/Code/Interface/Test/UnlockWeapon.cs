using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace JevLogin.Bridge
{
    public sealed class UnlockWeapon
    {
        public bool IsUnlock { get; set; }

        public UnlockWeapon(bool isUnlock)
        {
            IsUnlock = isUnlock;
        }
    }
}