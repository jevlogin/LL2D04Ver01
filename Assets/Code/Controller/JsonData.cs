using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;

namespace JevLogin
{
    public sealed class JsonData<T> : IData<T>
    {
        public List<T> LoadList(string path = null)
        {
            var jsonSerializer = new DataContractJsonSerializer(typeof(List<T>));

            using(var fileStream = new FileStream(path, FileMode.Open))
            {
                var newList = jsonSerializer.ReadObject(fileStream) as List<T>;
                return newList;
            }
        }

        public void SaveList(List<T> saveList, string path)
        {
            throw new System.NotImplementedException();
        }
    }
}