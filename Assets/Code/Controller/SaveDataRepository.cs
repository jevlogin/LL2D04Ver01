using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace JevLogin
{
    public sealed class SaveDataRepository
    {
        #region Fields

        private readonly IData<SaveData> _data;

        private const string _folderName = ManagerPath.DATA;
        private const string _fileName = ManagerName.DATA_JSON;
        private readonly string _path;

        #endregion


        #region ClassLifeCycles

        public SaveDataRepository(UnitCompositeFactory unitCompositeFactory)
        {
            _data = new JsonData<SaveData>();
            _path = Path.Combine(Application.dataPath, "Resources", _folderName);
        }

        #endregion

        #region Methods

        public void Load(List<object> listObjects)
        {
            var file = Path.Combine(_path, _fileName);
            if (!File.Exists(file))
            {
                Debug.Log($"File Not Found {file}");
                return;
            }

            var listSaveData = _data.LoadList(file);
            foreach (var item in listSaveData)
            {
                Debug.Log(item.Health);
            }

            for (int i = 0; i < listSaveData.Count; i++)
            {
                SaveData unit = listSaveData[i];
                Debug.Log(unit.Health);
            }
        }

        #endregion

    }
}