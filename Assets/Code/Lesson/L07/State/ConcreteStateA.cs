﻿namespace JevLogin.Lesson07.State
{
    public sealed class ConcreteStateA : State
    {
        public override void Handle(Context context)
        {
            context.State = new ConcreteStateB();
        }
    }
}