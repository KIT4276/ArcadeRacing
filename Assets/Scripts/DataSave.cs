using System.IO;
using UnityEngine;

namespace Racing
{
    public class DataSave : MonoBehaviour
    {
        public static void SaveJSON(object obj)
            => File.WriteAllText(EnterPanel._path, JsonUtility.ToJson(obj));
    }
}
