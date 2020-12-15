using UnityEngine;


namespace JevLogin
{
    public sealed class Pool
    {
        public string Tag { get; private set; }
        public GameObject Prefab { get; private set; }
        public int Size { get; private set; }
    }
}