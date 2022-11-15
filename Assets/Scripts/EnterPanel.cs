using System;
using System.IO;
using UnityEngine;

namespace Racing
{
    public class EnterPanel : MonoBehaviour //Player
    {
        //public static string _path;

        //[Serializable]
        //public class Data
        //{
        //    public string name;
        //    public TimeSpan time;
        //}
        //[SerializeField] Data data;
        //public static Data data;

        //private void Start()
        //{
        //    //data = new Data();

        //    _path = Path.Combine(Application.dataPath, "Save.json");
        //    data = DataLoad.LoadingJSON<Data>();
        //}

        //public static void Save(string name, TimeSpan time)
        //{
        //    data.name = name;
        //    data.time = time;
        //    File.WriteAllText(EnterPanel._path, JsonUtility.ToJson(name));
        //    File.WriteAllText(EnterPanel._path, JsonUtility.ToJson(time));
        //}

        //public static void SaveTime(object obj)
        //{
        //    File.WriteAllText(EnterPanel._path, JsonUtility.ToJson(EnterPanel._data.name));
        //}

        //private void OnApplicationQuit()
        //    => DataSave.SaveJSON(_data);
    }
}

