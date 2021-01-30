using UnityEngine;


namespace JevLogin.Decorator
{
    public sealed class Muffler : IMuffler
    {
        public GameObject MufflerInstance { get; }
        public float VolumeFireOnMuffler { get; }
        public AudioClip AudioClipMuffler { get; }
        public Transform BarrelPositionMuffler { get; }

        public Muffler(GameObject mufflerInstance, float volumeFireOnMuffler, AudioClip audioClipMuffler, Transform barrelPositionMuffler)
        {
            MufflerInstance = mufflerInstance;
            VolumeFireOnMuffler = volumeFireOnMuffler;
            AudioClipMuffler = audioClipMuffler;
            BarrelPositionMuffler = barrelPositionMuffler;
        }
    }
}