using UnityEngine;


namespace JevLogin.Lesson07.Strategy
{
    [CreateAssetMenu(fileName = "Rotate", menuName = "Data/Behaviour/Rotate", order = 1)]
    public sealed class RotateBehaviour : BaseBehaviour
    {
        public override void Behaviour(Transform value)
        {
            value.Rotate(Vector3.up * _speed);
        }
    }
}