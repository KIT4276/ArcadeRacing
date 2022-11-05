using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Racing
{
    public class BotInput : BaseInput
    {
        private int _index;

        [SerializeField, Range(0.1f, 3f)]
        private float _acceleration = 1;
        [SerializeField]
        private BotTargetPoint[] _points;
        [SerializeField]
        private float _slowDownTime = 3;

        private void Start()
        {
            OnRotate();
            Acceleration = _acceleration;
        }
        protected override void FixedUpdate()
        {
            OnRotate();
        }

        private float GetAngle()
        {
            var targetPos = _points[_index].transform.position;

            targetPos.y = transform.position.y;

            var direction = targetPos - transform.position;

            return Vector3.SignedAngle( transform.forward, direction, transform.up);
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.GetComponent<BotTargetPoint>() != null)
            {
                _index++;
                OnRotate();
                StartCoroutine(SlowDown());
            }
        }

        private IEnumerator SlowDown()
        {
            Acceleration = 0;
            yield return new WaitForSeconds(_slowDownTime);
            Acceleration = _acceleration;
        }

        private void OnRotate()
            => Rotate = Mathf.Clamp(Rotate + GetAngle() * (Time.fixedDeltaTime), -0.5f, 0.5f);
    }
}
