using UnityEngine;


namespace JevLogin.Bridge
{
    public interface IAmmunition
    {
        Rigidbody BulletInstance { get; }
        float TimeToDestroy { get; }
    }
}