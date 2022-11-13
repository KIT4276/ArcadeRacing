using System;
using System.IO;
using UnityEngine;

namespace Racing
{
    public class EnterPanel : MonoBehaviour
    {
        public static string _path;

        [Serializable]
        public class Data
        {
            public string _name;
            public TimeSpan _time;
        }
        [SerializeField] Data _data;

        private void Start()
        {
            _path = Path.Combine(Application.dataPath, "Save.json");
            _data = DataLoad.LoadingJSON<Data>();
        }

        private void OnApplicationQuit()
            => DataSave.SaveJSON(_data);
    }
}

