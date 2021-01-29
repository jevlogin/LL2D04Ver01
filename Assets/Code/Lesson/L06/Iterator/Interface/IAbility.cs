﻿namespace JevLogin.Iterator
{
    public interface IAbility 
    {
        string Name { get; }
        int Damage { get; }
        Target Target { get; }
        DamageType DamageType { get; }
    }
}