using UnityEngine;

namespace Racing
{
    public class CarColor : MonoBehaviour
    {
        [SerializeField]
        private Material _material1;
        [SerializeField]
        private Material _material2;
        [SerializeField]
        private Material _material3;
        [SerializeField]
        private Material _material4;
        [SerializeField]
        private Material _material5;

        public void CangeMaterial1()
            =>GetComponent<MeshRenderer>().material = _material1;
        public void CangeMaterial2()
            => GetComponent<MeshRenderer>().material = _material2;
        public void CangeMaterial3()
            => GetComponent<MeshRenderer>().material = _material3;
        public void CangeMaterial4()
            => GetComponent<MeshRenderer>().material = _material4;
        public void CangeMaterial5()
            => GetComponent<MeshRenderer>().material = _material5;


    }
}
