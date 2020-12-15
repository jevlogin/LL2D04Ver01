using UnityEngine;


namespace JevLogin
{
    public sealed class Bullet : MonoBehaviour
    {
        public int DamageAttack { get; private set; }
        public string Tag { get; private set; }
        public GameObject Prefab { get; private set; }
        public int Size { get; private set; }
    }
}