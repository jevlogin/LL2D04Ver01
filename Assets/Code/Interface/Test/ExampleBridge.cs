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

        private void Start()
        {
            IAmmunition ammunition = new BulletDecorator(_bullet, 3.0f);
            _fire = new Weapon(_barrelPosition, ammunition, 999.0f, _audioClip, _audioSource);
        }

        private void Update()
        {
            if (Input.GetButtonDown(AxisManager.FIRE1))
            {
                _fire.Fire();
            }
        }
    }
}