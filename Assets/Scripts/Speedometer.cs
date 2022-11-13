﻿using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Racing
{
    public class Speedometer : MonoBehaviour
    {
        private const float c_convertMeterInSecToKmInH = 3.6f;

        [SerializeField]
        private Transform _playerCar;

        [Space, SerializeField]
        private float _maxSpeed = 300f;
        [SerializeField]
        private Color _minColor = Color.yellow;
        [SerializeField]
        private Color _maxColor = Color.red;

        [Space, SerializeField, Range(0.1f, 1f)]
        private float _delay = 0.3f;

        [Space, SerializeField]
        private Text _text;

        private void Start()
            => StartCoroutine(Speed());

        private IEnumerator Speed()
        {
            var prevPos = _playerCar.position;
            while (true)
            {
                var distance = Vector3.Distance(prevPos, _playerCar.position);
                var speed = (float)System.Math.Round(distance / _delay * c_convertMeterInSecToKmInH, 1);

                _text.color = Color.Lerp(_minColor, _maxColor, speed/_maxSpeed);
                _text.text = speed.ToString();
                prevPos = _playerCar.position;
                yield return new WaitForSeconds(_delay);
            }
        }
    }
}
