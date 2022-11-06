using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Racing
{
    public class Countdown : MonoBehaviour
    {
        public static bool _isStarted;

        [SerializeField]
        private Text _text;
        [SerializeField]
        private int _count = 5;
        [SerializeField]
        private float _delayTime = 1;

        private void Start()
        {
            _text.text = _count.ToString();
            StartCoroutine(OnCountdown());
        }

        private IEnumerator OnCountdown()
        {
            while (_count > 0)
            {
                yield return new WaitForSeconds(_delayTime);
                _count--;
                _text.text = _count.ToString();
            }
            _text.text = "";
            _isStarted = true;
        }
    }
}
