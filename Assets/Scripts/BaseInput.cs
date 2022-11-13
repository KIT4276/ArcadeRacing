using System;
using UnityEngine;

namespace Racing
{
    public abstract class BaseInput : MonoBehaviour
    {
        public float Acceleration { get; protected set; }

        public float Rotate { get; protected set; }

        public event Action<bool> OnHandBrakeEvent;

        protected abstract void FixedUpdate();
        protected void CallHandBrake(bool value)
            => OnHandBrakeEvent?.Invoke(value);
    }
}
