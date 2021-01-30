using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


namespace JevLogin.Lesson06
{
    public sealed class Task03 : MonoBehaviour
    {
        #region Fields

        [SerializeField] private TMP_Text _text;
        [SerializeField] private TMP_InputField _inputField;

        #endregion


        #region UnityMethods

        private void Start()
        {
            _inputField.onValueChanged.AddListener(Interpret);
        }

        #endregion


        #region Methods

        private void Interpret(string value)
        {
            if (Int64.TryParse(value, out var number))
            {
                _text.text = ToMultiLong(number);
            }
        }

        private string ToMultiLong(long number)
        {
            if (number < 0 || number > long.MaxValue)
            {
                throw new ArgumentOutOfRangeException(nameof(number), $"insert value between 0 and {long.MaxValue}");
            }
            if (number < 1000)
            {
                return number.ToString();
            }
            if (number < 1_000_000)
            {
                return $"{number / (long)NumberEnum.K}{NumberEnum.K}";
            }
            if (number < 1_000_000_000)
            {
                return $"{number / (long)NumberEnum.M}{NumberEnum.M}";
            }
            if (number < 1_000_000_000_000)
            {
                return $"{number / (long)NumberEnum.B}{NumberEnum.B}";
            }
            if (number < 1_000_000_000_000_000)
            {
                return $"{number / (long)NumberEnum.T}{NumberEnum.T}";
            }

            throw new ArgumentOutOfRangeException(nameof(number));
        }

        #endregion

    }
}