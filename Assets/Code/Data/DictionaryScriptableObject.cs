using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace JevLogin
{
    [CreateAssetMenu(fileName = "New Dictionary Data", menuName = "Data/DictionaryData", order = 51)]
    public sealed class DictionaryScriptableObject : ScriptableObject
    {
        [SerializeField]
        private List<int> _keys = new List<int>();

        [SerializeField]
        private List<string> _values = new List<string>();

        public List<int> Keys { get => _keys; set => _keys = value; }
        public List<string> Values { get => _values; set => _values = value; }
    }
}