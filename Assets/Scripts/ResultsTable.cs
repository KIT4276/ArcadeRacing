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

        [Space, SerializeField]
        private PlayerInput _playerInput;
        [SerializeField]
        private GameObject _finishTimeText;
        [SerializeField]
        private GameObject _finishTimeTextShadow;

        //todo
    }
}
