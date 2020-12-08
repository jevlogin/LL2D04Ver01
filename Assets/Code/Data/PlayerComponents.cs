using System;
using UnityEngine;


namespace JevLogin
{
    [Serializable]
    public sealed class PlayerComponents
    {
        public Rigidbody Rigidbody;
        public AudioSource AudioSource;
        public Animator Animator;
        public Transform Transform;
    }
}