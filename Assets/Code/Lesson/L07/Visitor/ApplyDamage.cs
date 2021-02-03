namespace JevLogin.Lesson07.Visitor
{
    public sealed class ApplyDamage : IDealingDamage<Hit>
    {
        #region IDealingDamage

        public void Visit(Enemy hit, InfoCollision info)
        {
            hit.Health -= info.Damage;
            hit.TextMesh.text = hit.Health.ToString();
        }

        public void Visit(Enviroment hit, InfoCollision info)
        {
        }

        public void Visit(Knight hit, InfoCollision info)
        {
            var armor = hit.Armor;

            armor -= info.Damage;
            hit.Health -= armor;
            hit.TextMesh.text = hit.Health.ToString();
        }

        public void Visit(Hit hit, InfoCollision info)
        {
            if (hit is Knight knight)
            {
                var armor = knight.Armor;

                armor -= info.Damage;
                hit.Health -= armor;
                hit.TextMesh.text = hit.Health.ToString();
            }
            if (hit is Enemy)
            {
                hit.Health -= info.Damage;
                hit.TextMesh.text = hit.Health.ToString();
            }
            if (hit is Enviroment)
            {
            }
        }

        #endregion
    }
}