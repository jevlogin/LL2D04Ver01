using System.Collections.Generic;


namespace JevLogin
{
    public sealed class SaveListObject
    {
        public List<object> ListObject;

        public SaveListObject()
        {
            ListObject = new List<object>();
        }

        public SaveListObject(object _) : this()
        {
            ListObject.Add(_);
        }
    }
}