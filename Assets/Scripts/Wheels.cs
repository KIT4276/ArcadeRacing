using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Racing
{
    public class Wheels : MonoBehaviour
    {
        private WheelCollider[] _allWheelsColliders;

        [SerializeField]
        private Transform[] _wheelsFront;
        [SerializeField]
        private Transform[] _wheelsRear;

        [Space, SerializeField]
        private WheelCollider[] _wheelsColliderFront;
        [SerializeField]
        private WheelCollider[] _wheelsColliderRear;

        public WheelCollider[] GetFtontWheels => _wheelsColliderFront;
        public WheelCollider[] GetRearWheels => _wheelsColliderRear;

        public WheelCollider[] GetAllWheels => _allWheelsColliders;

        public void UpdateVisual(float angle)
        {
            for (int i = 0; i < _wheelsFront.Length; i++)
            {
                _wheelsColliderFront[i].steerAngle = angle;
                _wheelsColliderFront[i].GetWorldPose(out var pos, out var rotate);
                _wheelsFront[i].SetPositionAndRotation(pos,rotate);

                _wheelsColliderRear[i].GetWorldPose(out  pos, out  rotate);
                _wheelsRear[i].SetPositionAndRotation(pos, rotate);
            }
        }

        private void Start()
        {
            _allWheelsColliders = new WheelCollider[] { _wheelsColliderFront[0], _wheelsColliderFront[1], _wheelsColliderRear[0], _wheelsColliderRear[1] };
        }
    }
}
