using UnityEngine;


namespace JevLogin.Memento
{
    public sealed class PointInTime
    {
        #region Fields

        public Vector3 Position;
        public Quaternion Rotation;
        public Vector3 Velocity;
        public Vector3 AngularVelocity;

        #endregion


        #region ClassLifeCycles

        public PointInTime(Vector3 position, Quaternion rotation, Vector3 velocity, Vector3 angularVelocity)
        {
            Position = position;
            Rotation = rotation;
            Velocity = velocity;
            AngularVelocity = angularVelocity;
        }

        #endregion
    }
}