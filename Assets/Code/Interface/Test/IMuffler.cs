using UnityEngine;

namespace JevLogin.Bridge
{
    public interface IMuffler
    {
        AudioClip AudioClip { get; }
        float VolumeFireOnMuffler { get; }
        Transform BarrelPositionMuffler { get; }
        GameObject MufflerInstance { get; }
    }
}