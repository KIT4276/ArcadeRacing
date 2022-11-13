using System.IO;
using UnityEngine;

namespace Racing
{
    public class DataLoad : MonoBehaviour
    {
        public static T LoadingJSON<T>()
        {
            if (File.Exists(EnterPanel._path))
            {
                return JsonUtility.FromJson<T>(File.ReadAllText(EnterPanel._path));
            }
            else return default(T);
        }
    }
}
