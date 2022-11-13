using System;
using UnityEngine;
using UnityEngine.UI;

namespace Racing
{
    public class Timer : MonoBehaviour
    {
        public static TimeSpan _checkInTime;
        private DateTime _startTime;
        private string _time;

        [SerializeField]
        private Text _finishTime;
        [SerializeField]
        private Text _finishTimeShadow;
        [SerializeField]
        private Text _timer;

        private void Start()
            => _startTime = DateTime.Now;

        private void Update()
        {
            if (!Countdown._isStarted) return;
            if (Finish._isFinish)
            {
                _finishTime.text = "Время заезда " + _time + " Введите имя";
                _finishTimeShadow.text = _finishTime.text;
                _timer.text = "";
                
                return;
            }

            _checkInTime = DateTime.Now - _startTime;
            _time = _checkInTime.Minutes.ToString()+ ":" + _checkInTime.Seconds.ToString()+ ":" 
                + (10*_checkInTime.Milliseconds/1000).ToString();
            _timer.text = _time;
        }
    }
}
