using UnityEngine;

namespace DAZ4
{
    public class Viewport : MonoBehaviour
    {
        [SerializeField]
        private GameObject focus;

        [SerializeField]
        private float interpolation;

        private float shakeIntensity = 0;
        private int shakeCooldown = 0;

        protected Vector3 Cursor {
            get;
            private set;
        }

        protected void Start()
        {
            Cursor = new Vector3(focus.transform.position.x, focus.transform.position.y);
        }

        protected void LateUpdate()
        {
            Vector3 destination = Vector3.Lerp(
                focus.transform.position,
                Camera.main.ScreenToWorldPoint(Input.mousePosition),
                interpolation
            );

            if (shakeCooldown > 0)
            {
                Vector3 shake = Random.insideUnitCircle * shakeIntensity;
                Cursor += shake;

                shakeCooldown -= 1;

                if (shakeCooldown <= 0)
                {
                    shakeCooldown = 0;
                    shakeIntensity = 0;
                }
            }

            Cursor -= (Cursor - destination) / 10;
            transform.position = new Vector3(Cursor.x, Cursor.y, transform.position.z);
        }

        public void Shake(int duration, float intensity)
        {
            shakeCooldown = duration;
            shakeIntensity = intensity;
        }
    }
}