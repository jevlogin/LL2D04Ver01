﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace JevLogin.Decorator
{
    public sealed class Example : MonoBehaviour
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
            IAmmunition ammunition = new Bullet(_bullet, 3.0f);
            var weapon = new Weapon(_barrelPosition, _audioClip, _audioSource, ammunition, 999.0f);

            var muffler = new Muffler(_muffler, _volumeFireOnMuffler, _audioClipMuffler, _barrelPositionMuffler);

            ModificationWeapon modificationWeapon = new ModificationMuffler(_audioSource, muffler, _barrelPositionMuffler.position);
            modificationWeapon.ApplyModification(weapon);

            _fire = modificationWeapon;

            //_fire = weapon;

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