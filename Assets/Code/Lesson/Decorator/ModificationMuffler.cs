using UnityEngine;


namespace JevLogin.Decorator
{
    public sealed class ModificationMuffler : ModificationWeapon
    {
        private readonly AudioSource _audioSource;
        private readonly IMuffler _muffler;
        private readonly Vector3 _mufflerPosition;

        public ModificationMuffler(AudioSource audioSource, IMuffler muffler, Vector3 mufflerPosition)
        {
            _audioSource = audioSource;
            _muffler = muffler;
            _mufflerPosition = mufflerPosition;
        }

        protected override Weapon AddModification(Weapon weapon)
        {
            var muffler = Object.Instantiate(_muffler.MufflerInstance, _mufflerPosition, Quaternion.Euler(90.0f, 0.0f, 0.0f));
            _audioSource.volume = _muffler.VolumeFireOnMuffler;
            weapon.SetAudioClip(_muffler.AudioClipMuffler);
            weapon.SetBarrelPosition(_muffler.BarrelPositionMuffler);
            return weapon;
        }

    }
}