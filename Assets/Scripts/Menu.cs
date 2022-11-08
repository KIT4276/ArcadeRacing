using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Racing
{
    public class Menu : MonoBehaviour
    {
        public void StartRace()
            =>SceneManager.LoadScene(1);

        public void StartTuning()
            => SceneManager.LoadScene(2);

        public void Exit()
        {
#if UNITY_EDITOR           
            UnityEditor.EditorApplication.isPlaying = false;
#endif
            Application.Quit();
        }
    }
}
