using UnityEngine;


namespace JevLogin.Lesson07.State
{
    public sealed class StateTest : MonoBehaviour
    {
        private void Start()
        {
            Context context = new Context(new ConcreteStateA());
            context.Request();
            context.Request();
            context.Request();
            context.Request();
        }
    }
}