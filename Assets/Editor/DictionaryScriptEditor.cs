using UnityEditor;
using UnityEngine;


namespace JevLogin
{
    [CustomEditor(typeof(Task01))]
    public sealed class DictionaryScriptEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            if (((Task01)target).ModifyValues)
            {
                if (GUILayout.Button("Save Changes"))
                {
                    ((Task01)target).DeserializeDictionary();
                }
            }
        }
    }
}