using System.Collections.Generic;


namespace JevLogin
{
    public interface IData<T>
    {
        List<T> LoadList(string path = null);
        void SaveList(List<T> saveList, string path);
    }
}