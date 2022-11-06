﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Racing
{
    public class PlayerInput : BaseInput
    {
        private Controls _controls;

        private void Awake()
        {
            _controls = new Controls();
            _controls.Car.HandBrake.performed += _ => CallHandBrake(true);
            _controls.Car.HandBrake.canceled += _ => CallHandBrake(false);
        }

        protected override void FixedUpdate()
        {
            if (!Countdown._isStarted) return;
            
            var direction = _controls.Car.Rotate.ReadValue<float>();

            if(direction == 0f && Rotate != 0f)
            {
                Rotate = Rotate > 0f
                    ? Rotate - Time.fixedDeltaTime
                    : Rotate + Time.fixedDeltaTime;
            }
            else
            {
                Rotate = Mathf.Clamp(Rotate + direction * (Time.fixedDeltaTime), -1f, 1f);
            }
            Acceleration = _controls.Car.Acceleration.ReadValue<float>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<Finish>() != null)
            {
                Debug.Log("Fin!");
                Acceleration = 0f;
                Finish._isFinish = true;
                _controls.Car.Disable();
            }
        }

        private void OnEnable()
            =>_controls.Car.Enable();

        private void OnDestroy()
            => _controls.Dispose();
    }
}
