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

        protected Vector3 Cursor {
            get;
            private set;
        }

        void Start()
        {
            Transform = GetComponent<Transform>();
            Cursor = new Vector3(Focus.transform.position.x, Focus.transform.position.y);
        }

        void LateUpdate()
        {
            Vector3 destination = Vector3.Lerp(Focus.transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition), Interpolation);

            Cursor -= (Cursor - destination) / 10;
            Transform.position = new Vector3(Cursor.x, Cursor.y, Transform.position.z);
        }
    }
}