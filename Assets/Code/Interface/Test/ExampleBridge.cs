using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace JevLogin.Bridge
{
    public sealed class ExampleBridge : MonoBehaviour
    {
        private IFire _fire;
        [Header("Start Gun")]
        [SerializeField] private Rigidbody _bullet;
        [SerializeField] private Transform _barrelPosition;
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioClip _audioClip;

        [Header("Muffler Gun")]
        [SerializeField] private AudioClip _audioClipMuffler;
        [SerializeField] private float _volumeFireOnMuffler;
        [SerializeField] private Transform _barrelPositionMuffler;
        [SerializeField] private GameObject _muffler;



        private void Start()
        {
            var unlockWeapon = new UnlockWeapon(false);
            var weapon = new WeaponPro();
            var weaponProxy = new WeaponProxy(weapon, unlockWeapon);
            weaponProxy.Fire();
            unlockWeapon.IsUnlock = true;
            weaponProxy.Fire();
        }
    }
}