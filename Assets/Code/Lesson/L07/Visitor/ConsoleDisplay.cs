using UnityEngine;


namespace JevLogin.Lesson07.Visitor
{
    public sealed class ConsoleDisplay : IDealingDamage<Hit>
    {
        #region IDealingDamage

        public void Visit(Enemy hit, InfoCollision info)
        {
            Debug.Log($"{nameof(Enemy)} - {info.Damage}");
        }

        public void Visit(Enviroment hit, InfoCollision info)
        {
            Debug.Log($"{nameof(Enviroment)} - {info.Damage}");
        }

        public void Visit(Knight hit, InfoCollision info)
        {
            Debug.Log($"{nameof(Knight)} - {info.Damage}");
        }

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