using System.Collections;
using System.Collections.Generic;


namespace JevLogin.Iterator
{
    public interface IEnemy
    {
        IEnumerator GetEnumerator();
        IEnumerable<IAbility> GetAbility();
        IEnumerable<IAbility> GetAbility(DamageType index);
        IAbility this[int index] { get; }
        string this[Target index] { get; }
        int MaxDamage { get; }
    }
}