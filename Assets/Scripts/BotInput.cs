using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Racing
{
    public class BotInput : BaseInput
    {
        private int _index;

        [SerializeField]
        private BotTargetPoint[] _points;

        private void Start()
        {
            GetAngle();
        }
        protected override void FixedUpdate()
        {
            Acceleration = 1f;
        }

        private float GetAngle()
        {
            var targetPos = _points[_index].transform.position;
            Debug.Log(_points[_index].transform.name);
            targetPos.y = transform.position.y;

            var direction = targetPos - transform.position;

            return Vector3.SignedAngle(direction, transform.forward, transform.up);
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.GetComponent<BotTargetPoint>() != null)
            {
                _index++;
                GetAngle();
            }
        }
    }
}
