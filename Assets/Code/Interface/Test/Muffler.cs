using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace JevLogin.Bridge
{
    public sealed class Muffler : IMuffler
    {
        public AudioClip AudioClip { get; }
        public Transform BarrelPositionMuffler { get; }
        public GameObject MufflerInstance { get; }
        public float VolumeFireOnMuffler { get; }

        public Muffler(AudioClip audioClip, Transform barrelPositionMuffler, GameObject mufflerInstance, float volumeFireOnMuffler)
        {
            AudioClip = audioClip;
            BarrelPositionMuffler = barrelPositionMuffler;
            MufflerInstance = mufflerInstance;
            VolumeFireOnMuffler = volumeFireOnMuffler;
        }
    }
}