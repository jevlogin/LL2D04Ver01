using System.Collections.Generic;
using UnityEngine;


namespace JevLogin
{
    public sealed class Task01 : MonoBehaviour, ISerializationCallbackReceiver
    {
        #region Fields

        [SerializeField] private DictionaryScriptableObject _dictionaryScriptableObject;

        [SerializeField]
        private List<int> _keys = new List<int>();

        [SerializeField]
        private List<string> _values = new List<string>();

        [SerializeField]
        private Dictionary<int, string> _keyValuePairs = new Dictionary<int, string>();

        public bool ModifyValues;

        #endregion


        #region UnityMethods

        private void Awake()
        {
            for (int i = 0; i < Mathf.Min(_dictionaryScriptableObject.Keys.Count, _dictionaryScriptableObject.Values.Count); i++)
            {
                _keyValuePairs.Add(_dictionaryScriptableObject.Keys[i], _dictionaryScriptableObject.Values[i]);
            }
        }

        public void OnAfterDeserialize()
        {
        }

        public void OnBeforeSerialize()
        {
            if (!ModifyValues)
            {
                _keys.Clear();
                _values.Clear();

                for (int i = 0; i < Mathf.Min(_dictionaryScriptableObject.Keys.Count, _dictionaryScriptableObject.Values.Count); i++)
                {
                    _keys.Add(_dictionaryScriptableObject.Keys[i]);
                    _values.Add(_dictionaryScriptableObject.Values[i]);
                }
            }
        }

        #endregion


        #region Methods

        public void DeserializeDictionary()
        {
            _keyValuePairs = new Dictionary<int, string>();
            _dictionaryScriptableObject.Keys.Clear();
            _dictionaryScriptableObject.Values.Clear();
            for (int i = 0; i < Mathf.Min(_keys.Count, _values.Count); i++)
            {
                _dictionaryScriptableObject.Keys.Add(_keys[i]);
                _dictionaryScriptableObject.Values.Add(_values[i]);
                _keyValuePairs.Add(_keys[i], _values[i]);
            }
            ModifyValues = false;
        }

        #endregion
    }
}