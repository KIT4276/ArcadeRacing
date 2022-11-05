using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Racing
{
    [RequireComponent(typeof(Wheels), typeof(BaseInput), typeof(Rigidbody))]
    public class Car : MonoBehaviour
    {
        private Wheels _wheels;
        private BaseInput _baseInput;
        private Rigidbody _rigidbody;

        [SerializeField, Range(5f, 60f)]
        private float _maxSteerAngle = 25f;
        [SerializeField]
        private float _torque = 2500f;
        [SerializeField, Range(0f, float.MaxValue)]
        private float _handBrakeTorque = float.MaxValue;
        [SerializeField]
        private Vector3 _centerOfMass;

        private void Start()
        {
            _wheels = GetComponent<Wheels>();
            _baseInput = GetComponent<BaseInput>();
            _rigidbody = GetComponent<Rigidbody>();
            _rigidbody.centerOfMass = _centerOfMass;
            _baseInput.OnHandBrakeEvent += OnHandBrake;
        }

        private void FixedUpdate()
        {
            _wheels.UpdateVisual(_baseInput.Rotate * _maxSteerAngle);
            var torque = _baseInput.Acceleration * _torque / 2f;

            foreach (var wheel in _wheels.GetFtontWheels)
                wheel.motorTorque = torque;
        }

        private void OnHandBrake(bool value)
        {
            if (value)
            {
                foreach (var wheel in _wheels.GetRearWheels)
                {
                    wheel.brakeTorque = _handBrakeTorque;
                    wheel.motorTorque = 0f;
                }
            }
            else
            {
                foreach (var wheel in _wheels.GetRearWheels)
                    wheel.brakeTorque = 0f;
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawSphere(transform.TransformPoint(_centerOfMass), .3f);
        }

        private void OnDestroy()
        {
            _baseInput.OnHandBrakeEvent -= OnHandBrake;
        }
    }
}
