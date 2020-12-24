﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace JevLogin.Bridge   
{
    public sealed class Weapon : IFire
    {
        private Transform _barrelPosition;
        private IAmmunition _bullet;
        private float _force;
        private AudioClip _audioClip;
        private readonly AudioSource _audioSource;

        public Weapon(Transform barrelPosition, IAmmunition bullet, float force, AudioClip audioClip, AudioSource audioSource)
        {
            _barrelPosition = barrelPosition;
            _bullet = bullet;
            _force = force;
            _audioClip = audioClip;
            _audioSource = audioSource;
        }

        public void SetBarrelposition(Transform barrelPosition)
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
            Object.Destroy(bullet.gameObject, _bullet.TimeToDestroy);
            _audioSource.PlayOneShot(_audioClip);
        }
    }
}