using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace JevLogin.Decorator
{
    public sealed class Weapon : IFire
    {
        private Transform _barrelPosition;
        private AudioClip _audioClip;
        private readonly AudioSource _audioSource;
        private IAmmunition _bullet;

        private float _force;

        public Weapon(Transform barrelPosition, AudioClip audioClip, AudioSource audioSource, IAmmunition bullet, float force)
        {
            _barrelPosition = barrelPosition;
            _audioClip = audioClip;
            _audioSource = audioSource;
            _bullet = bullet;
            _force = force;
        }

        public void SetBarrelPosition(Transform barrelPosition)
        {
            _barrelPosition = barrelPosition;
        }

        public void SetBullet(IAmmunition bullet)
        {
            _bullet = bullet;
        }

        public void SetForce(float force)
        {
            _force = force;
        }

        public void SetAudioClip(AudioClip audioClip)
        {
            _audioClip = audioClip;
        }

        public void Fire()
        {
            var bullet = Object.Instantiate(_bullet.BulletInstance, _barrelPosition.position, Quaternion.identity);
            bullet.AddForce(_barrelPosition.forward * _force);
            Object.Destroy(bullet.gameObject, _bullet.TimeDestroy);
            _audioSource.PlayOneShot(_audioClip);
        }
    }
}