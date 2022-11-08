using UnityEngine;
using UnityEngine.UI;

namespace Racing
{
    public class TuningCamera : MonoBehaviour
    {
        [SerializeField]
        private float _rotateSpeed;

        [SerializeField]
        private Button _buttonRight;
        [SerializeField]
        private Button _buttonLeft;

        public void RightRotate()
            => Rotate(true);


        public void LeftRotate()
            => Rotate(false);

        public void Rotate(bool right)
        {
            var angle = transform.eulerAngles;

            angle.x = 0f;
            if (right) 
                angle.y += _rotateSpeed;
            else 
                angle.y -= _rotateSpeed;
            angle.z = 0f;

            transform.eulerAngles = angle;
        }
    }
}
