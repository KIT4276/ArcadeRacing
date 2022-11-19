using System.Collections;
using UnityEngine;

namespace Racing
{
    public class PlayerInput : BaseInput
    {
        private Controls _controls;

        [SerializeField]
        private GameObject _enterPanel;
        

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
                Acceleration = 0f;
                Finish._isFinish = true;
                _controls.Car.Disable();
                StartCoroutine(MovePanel(_enterPanel));
            }
        }

        public IEnumerator MovePanel(GameObject panel)
        {
            var currentTime = 0f;
            var startPos = panel.GetComponent<RectTransform>().transform.position;
            var targetPos = new Vector3(startPos.x, startPos.y + 532, startPos.z);

            while (currentTime < 2)
            {
                panel.GetComponent<RectTransform>().transform.position = Vector2.Lerp(startPos, targetPos, currentTime / 2);
                currentTime += Time.deltaTime;
                yield return null;
            }
            panel.GetComponent<RectTransform>().transform.position = targetPos;
        }

        private void OnEnable()
            =>_controls.Car.Enable();

        private void OnDestroy()
            => _controls.Dispose();
    }
}
