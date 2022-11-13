using System;
using UnityEngine;
using UnityEngine.UI;

namespace Racing
{
    public class ResultsTable : MonoBehaviour
    {
        [SerializeField]
        private InputField _inputField;
        [SerializeField]
        private Button _button;

        [Space, SerializeField]
        private Text _name1;
        [SerializeField]
        private Text _time1;

        public void SaveText()
        {
            DataSave.SaveJSON(_inputField.text);
            DataSave.SaveJSON(Timer._checkInTime);

            Debug.Log(_inputField.text);
            Debug.Log(Timer._checkInTime);
        }

        public void ShowText()
        {
            _name1.text = DataLoad.LoadingJSON<string>();
            _time1.text = DataLoad.LoadingJSON<TimeSpan>().ToString();
            _inputField.gameObject.SetActive(false);
            _button.gameObject.SetActive(false);
        }
    }
}
