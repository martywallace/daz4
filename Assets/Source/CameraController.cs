using UnityEngine;

namespace DAZ4
{
    public class CameraController : MonoBehaviour
    {
        public GameObject Focus;
        public float Interpolation;

        public Transform Transform
        {
            get;
            private set;
        }

        void Start()
        {
            Transform = GetComponent<Transform>();
        }

        void LateUpdate()
        {
            Vector3 delta = Vector3.Lerp(Focus.transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition), Interpolation);

            Transform.position = new Vector3(delta.x, delta.y, Transform.position.z);
        }
    }
}