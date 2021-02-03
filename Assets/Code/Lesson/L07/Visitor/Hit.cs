using TMPro;
using UnityEngine;


namespace JevLogin.Lesson07.Visitor
{
    public abstract class Hit : MonoBehaviour
    {
        public float Health;
        public TextMeshPro TextMesh;
        public abstract void Activate(IDealingDamage<Hit> value, float damage);
    }
}