using System.Runtime.Serialization;

namespace JevLogin
{
    [System.Serializable, DataContract]
    public sealed class SaveData
    {
        [DataMember]
        public UnitType Type;

        [DataMember]
        public int Health;
    }
}