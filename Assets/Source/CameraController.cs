using UnityEngine;

namespace DAZ4
{
    public class CameraController : MonoBehaviour
    {
        public GameObject Focus;
        public float Interpolation;

        protected Vector3 Cursor {
            get;
            private set;
        }

        void Start()
        {
            Cursor = new Vector3(Focus.transform.position.x, Focus.transform.position.y);
        }

        void LateUpdate()
        {
            Vector3 destination = Vector3.Lerp(Focus.transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition), Interpolation);

            Cursor -= (Cursor - destination) / 10;
            transform.position = new Vector3(Cursor.x, Cursor.y, transform.position.z);
        }
    }
}