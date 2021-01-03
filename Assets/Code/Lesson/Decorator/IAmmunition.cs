using UnityEngine;


namespace JevLogin.Decorator
{
    public interface IAmmunition
    {
        Rigidbody BulletInstance { get; }
        float TimeDestroy { get; }
    }
}