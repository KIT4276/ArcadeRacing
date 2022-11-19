using System;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

namespace Racing
{
    public class DataSave : MonoBehaviour
    {
        public static string _path;

        [SerializeField]
        private InputField _inputField;
        

        [Serializable]
        public class Data
        {
            public string playerName;
            public int mitutes;
            public int seconds;
            public int tenthOfSecond;
        }

        Data data = new Data();

        private void Start()
            => _path = Path.Combine(Application.dataPath, "Test.json");

        public void SaveLeader()
        {
            data.playerName = _inputField.text;
            data.mitutes = Timer._checkInTime.Minutes;
            data.seconds = Timer._checkInTime.Seconds;
            data.tenthOfSecond = Timer._checkInTime.Milliseconds/100;

            string json = JsonUtility.ToJson(data);

            File.AppendAllText(_path, json + "\n");
        }

        public void LoadLeader()
        {
            var r =  JsonUtility.FromJson<Data>(File.ReadAllText(_path));
            Debug.Log(r);
        }
    }
}
