using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Racing
{
    public class DataLoad : MonoBehaviour
    {
        private Dictionary<string, DateTime> _playersResults;
        private string[] _names;


        private void Start()
        {
            _names = new string[9];
            //_names = FillNames();
            FillNames();
        }

        private void FillNames()
        {
            if (File.Exists(DataSave._path))
            {
                for (int i = 0; i < _names.Length; i++)
                {
                    _names[i] = LoadingJSON<string>();
                }
            }
            //return LoadingJSON<string>();

            
        }

        public static T LoadingJSON<T>()
        {
            if (File.Exists(DataSave._path))
            {
                return JsonUtility.FromJson<T>(File.ReadAllText(DataSave._path));
            }
            else return default(T);
        }
    }
}
