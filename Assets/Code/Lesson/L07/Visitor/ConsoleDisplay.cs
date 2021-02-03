using UnityEngine;


namespace JevLogin.Lesson07.Visitor
{
    public sealed class ConsoleDisplay : IDealingDamage<Hit>
    {
        #region IDealingDamage

        public void Visit(Hit hit, InfoCollision info)
        {
            if (hit is Knight knight)
            {
                Debug.Log($"{nameof(Knight)} - {knight.Health}");
            }
            if (hit is Enemy enemy)
            {
                Debug.Log($"{nameof(Enemy)} - {enemy.Health}");
            }
            if (hit is Enviroment)
            {
                Debug.Log($"{nameof(Enviroment)} - {info.Damage}");
            }
        }

        #endregion
    }
}