using UnityEngine;


namespace JevLogin
{
    [System.Serializable]
    public sealed class Pool
    {
        private string _tag;
        private int _size;

        public Pool(string tag, int size)
        {
            Tag = tag;
            Size = size;
        }

        public string Tag
        {
            get
            {
                return _tag;
            }
            private set
            {
                _tag = value;
            }
        }

        public GameObject Prefab { get; set; }
        public int Size { get { return _size; } private set => _size = value; }
    }
}