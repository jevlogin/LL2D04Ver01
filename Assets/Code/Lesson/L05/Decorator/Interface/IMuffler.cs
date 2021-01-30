using UnityEngine;


namespace JevLogin.Decorator
{
    public interface IMuffler
    {
        GameObject MufflerInstance { get; }
        float VolumeFireOnMuffler { get; }
        AudioClip AudioClipMuffler { get; }
        Transform BarrelPositionMuffler { get; }
    }
}