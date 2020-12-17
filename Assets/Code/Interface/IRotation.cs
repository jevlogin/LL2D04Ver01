using UnityEngine;


namespace JevLogin
{
    public interface IRotation : IController
    {
        void Rotation(Vector3 direction);
    }
}