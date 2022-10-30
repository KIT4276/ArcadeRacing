using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Racing
{
    public abstract class BaseInput : MonoBehaviour
    {
        public float Acceleration { get; protected set; }

        public float Rotate { get; protected set; }

        public event Action<bool> OnHandBrakeEvent;

        protected abstract void FixedUpdate();
        protected abstract void Start();

        protected void CallHandBrake(bool value)
            => OnHandBrakeEvent?.Invoke(value);
    }
}
